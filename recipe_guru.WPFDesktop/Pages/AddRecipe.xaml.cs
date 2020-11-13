using recipe_guru.WPFDesktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace recipe_guru.WPFDesktop.Pages
{
    /// <summary>
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Page
    {
        private int BookId;

        public AddRecipe(int BookId)
        {
            InitializeComponent();

            this.BookId = BookId;
        }

        private readonly APIService _ReceptService = new APIService("Recept");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");
        private readonly APIService _ReceptSastojakService = new APIService("ReceptSastojak");
        private readonly APIService _ReceptPregledService = new APIService("ReceptPregled");
        private readonly APIService _KategorijeService = new APIService("Kategorije");
        private bool updatedImage = false;

        public event PropertyChangedEventHandler PropertyChanged;

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
            if (updatedImage == false)
            {
                MessageBox.Show("Please choose an image", "Warning", MessageBoxButton.OK);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRecipeName.Text) || string.IsNullOrWhiteSpace(new TextRange(txtRecipeDescription.Document.ContentStart, txtRecipeDescription.Document.ContentEnd).Text) || Sastojci.Count == 0 || KategorijePicker.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtEffort.Text))
            {
                MessageBox.Show("All fields are required!", "Warning", MessageBoxButton.OK);
                return;
            }

            try
            {
                Int32.Parse(txtEffort.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Effort ammount needs to be a  valid number", "Warning", MessageBoxButton.OK);
                return;
            }


            if (txtRecipeName.Text.Length > 20)
            {
                MessageBox.Show("Book Name must be less than 20 characters long!", "Warning", MessageBoxButton.OK);
                return;
            }

            try
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
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception occured: " + ex.Message, "Error", MessageBoxButton.OK);
                throw;
            }

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
