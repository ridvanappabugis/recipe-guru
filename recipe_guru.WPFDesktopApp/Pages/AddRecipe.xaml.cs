using recipe_guru.WPFDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Page
    {
        private int BookId;
        private bool isUpdate;
        private int? RecipeId;
        private int? PreglediId;

        public AddRecipe(int BookId, bool isUpdate, int? recipeId)
        {
            InitializeComponent();

            this.BookId = BookId;
            this.isUpdate = isUpdate;
            this.RecipeId = recipeId;
        }

        private readonly APIService _ReceptService = new APIService("Recept");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");
        private readonly APIService _ReceptSastojakService = new APIService("ReceptSastojak");
        private readonly APIService _ReceptPregledService = new APIService("ReceptPregled");
        private readonly APIService _KategorijeService = new APIService("Kategorije");
        private bool updatedImage = false;


        public ObservableCollection<Model.Kategorija> Kategorije { get; set; } = new ObservableCollection<Model.Kategorija>();
        public ObservableCollection<ReceptSastojakListViewItem> Sastojci { get; set; } = new ObservableCollection<ReceptSastojakListViewItem>();

        protected async void loaded_handler(object sender, RoutedEventArgs e)
        {
            PopulateUi();
        }

        private async void PopulateUi()
        {
            var kategorijeList = await _KategorijeService.Get<List<Model.Kategorija>>(null);

            foreach (var kat in kategorijeList)
            {
                Kategorije.Add(kat);
            }
            KategorijePicker.ItemsSource = Kategorije;

            if (isUpdate)
            {
                {
                    try
                    {
                        Model.Recept recept = await _ReceptService.GetById<Model.Recept>(RecipeId);

                        var oldPregledi = await _ReceptPregledService.GetById<Model.ReceptPregled>(recept.ReceptPregledId);

                        await _ReceptPregledService.Update<Model.ReceptPregled>(oldPregledi.Id, new Model.Requests.ReceptPregledUpsertRequest
                        {
                            BrojPregleda = oldPregledi.BrojPregleda++
                        });

                        Model.Kategorija kat = await _KategorijeService.GetById<Model.Kategorija>(recept.KategorijaId);
                        Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(recept.ImageResourceId);
                        img_BookImage.ImageSource = imageResource != null ? new ImageService().arrayToImageSource(imageResource.ImageByteValue) : new ImageService().uriToImageSource("/Images/logo.png");

                        txtRecipeName.Text = recept.Naziv;
                        txtEffort.Text = recept.DuzinaPripreme.ToString();
                        txtRecipeDescription.AppendText(recept.Deskripcija);
                        PreglediId = recept.ReceptPregledId;

                        Sastojci.Clear();

                        var lista = await _ReceptSastojakService.Get<List<Model.ReceptSastojak>>(new Model.Requests.ReceptSastojakSearchRequest
                        {
                            ReceptId = RecipeId.Value
                        });

                        foreach (var sastojak in lista)
                        {
                            Sastojci.Add(new ReceptSastojakListViewItem {
                                Id = sastojak.Id,
                                Ammount = Int32.Parse(sastojak.Kolicina),
                                Naziv = sastojak.Naziv
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unhandled exception: " + ex.Message, "Error", MessageBoxButton.OK);
                    }
                }

            }

            SastojciList.ItemsSource = Sastojci;
        }

        private  void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32.Parse(txtIngAmmpunt.Text);
            } catch(Exception ex)
            {
                MessageBox.Show("Ammount needs to be a valid number", "Warning", MessageBoxButton.OK);
                return;
            }

            Sastojci.Add(new ReceptSastojakListViewItem
            {
                Ammount = Int32.Parse(txtIngAmmpunt.Text),
                Naziv = txtIngName.Text
            });

            txtIngAmmpunt.Clear();
            txtIngName.Clear();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!validate())
            {
                return;
            }
          
            try
            {
                int? imageResourceId = await addImage();

                if (!isUpdate)
                {
                    saveNewRecipe(imageResourceId);
                } else
                {
                    updateRecipe(imageResourceId);
                }

                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception occured: " + ex.Message, "Error", MessageBoxButton.OK);
                throw;
            }

        }
        
        private async Task<int?> addImage()
        {
            byte[] data = new ImageService().bitmapToArray(img_BookImage.ImageSource as BitmapImage);

            int? imageResourceId = null;
            if (img_BookImage.ImageSource != null)
            {
                Model.ImageResource imageResource = await _ImageResourceService.Insert<Model.ImageResource>(new Model.Requests.ImageResourceUpsertRequest
                {
                    ImageByteValue = data
                });
                imageResourceId = imageResource.Id;
            }

            return imageResourceId;
        }

        private async void saveNewRecipe(int? imageResourceId)
        {
            var pregeldi = await _ReceptPregledService.Insert<Model.ReceptPregled>(new Model.Requests.ReceptPregledUpsertRequest
            {
                BrojPregleda = 0
            });

            var recept = await _ReceptService.Insert<Model.Recept>(new Model.Requests.ReceptUpsertRequest
            {
                KnjigaRecepataId = BookId,
                ImageResourceId = imageResourceId,
                DuzinaPripreme = Convert.ToInt32(txtEffort.Text),
                KategorijaId = ((Model.Kategorija)KategorijePicker.SelectedItem).Id,
                Naziv = txtRecipeName.Text,
                Public = true,
                Deskripcija = new TextRange(txtRecipeDescription.Document.ContentStart, txtRecipeDescription.Document.ContentEnd).Text,
                ReceptPregledId = pregeldi.Id
            });

            foreach (var sastojak in Sastojci)
            {
                await _ReceptSastojakService.Insert<Model.ReceptSastojak>(new Model.Requests.ReceptSastojakUpsertRequest
                {
                    ReceptId = recept.Id,

                    Kolicina = sastojak.Ammount + "",
                    Naziv = sastojak.Naziv
                });
            }

            MessageBox.Show("Added recipe succesfully.", "Success", MessageBoxButton.OK);
        }

        private async void updateRecipe(int? imageResourceId)
        {

            var recept = await _ReceptService.Update<Model.Recept>(RecipeId.Value, new Model.Requests.ReceptUpsertRequest
            {
                KnjigaRecepataId = BookId,
                ImageResourceId = imageResourceId,
                DuzinaPripreme = Convert.ToInt32(txtEffort.Text),
                KategorijaId = ((Model.Kategorija)KategorijePicker.SelectedItem).Id,
                Naziv = txtRecipeName.Text,
                Public = true,
                Deskripcija = new TextRange(txtRecipeDescription.Document.ContentStart, txtRecipeDescription.Document.ContentEnd).Text,
                ReceptPregledId = PreglediId
            }) ;

            foreach (var sastojak in Sastojci)
            {
                if (sastojak.Id == null)
                {
                    await _ReceptSastojakService.Insert<Model.ReceptSastojak>(new Model.Requests.ReceptSastojakUpsertRequest
                    {
                        ReceptId = RecipeId.Value,
                        Kolicina = sastojak.Ammount + "",
                        Naziv = sastojak.Naziv
                    });
                }
            }

            MessageBox.Show("Edited recipe succesfully.", "Success", MessageBoxButton.OK);
        }

        private bool validate()
        {
            if (!isUpdate && updatedImage == false)
            {
                MessageBox.Show("Please choose an image", "Warning", MessageBoxButton.OK);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRecipeName.Text) || string.IsNullOrWhiteSpace(new TextRange(txtRecipeDescription.Document.ContentStart, txtRecipeDescription.Document.ContentEnd).Text) || Sastojci.Count == 0 || KategorijePicker.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtEffort.Text))
            {
                MessageBox.Show("All fields are required!", "Warning", MessageBoxButton.OK);
                return false;
            }

            try
            {
                Int32.Parse(txtEffort.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Effort ammount needs to be a  valid number", "Warning", MessageBoxButton.OK);
                return false;
            }


            if (txtRecipeName.Text.Length > 40)
            {
                MessageBox.Show("Recipe Name must be over 40 characters long!", "Warning", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        private void btnPickImage_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new ImageService().loadImage();

            if (image != null)
            {
                updatedImage = true;
                img_BookImage.ImageSource = image;

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
