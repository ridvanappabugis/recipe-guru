using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace recipe_guru.WPFDesktop.Pages
{
    /// <summary>
    /// Interaction logic for Recipe.xaml
    /// </summary>
    public partial class Recipe : Page
    {
        private int KnjigaId;
        private int RecipeId;
        private string KnjigaNaziv;
        private bool isUser;
        private bool isVisitor;

        public Recipe(string KnjigaNaziv, int RecipeId, bool isUser)
        {
            InitializeComponent();

            this.KnjigaNaziv = KnjigaNaziv;
            this.RecipeId = RecipeId;

            this.isUser = isUser;
            this.isVisitor = !isUser;
        }

        private readonly APIService _ReceptService = new APIService("Recept");
        private readonly APIService _ReceptSastojciService = new APIService("ReceptSastojak");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");
        private readonly APIService _KategorijeService = new APIService("Kategorije");
        private readonly APIService _RatingService = new APIService("Rating");
        private readonly APIService _ReceptPregledService = new APIService("ReceptPregled");

        public ObservableCollection<string> Sastojci { get; set; } = new ObservableCollection<string>();
        protected async void loaded_handler(object sender, RoutedEventArgs e)
        {
            Init();
            SastojciList.ItemsSource = Sastojci;
            UserOptions.Visibility = isUser? Visibility.Visible : Visibility.Hidden;
            VisitorOptions.Visibility = isVisitor ? Visibility.Visible : Visibility.Hidden;

        }

        private async void Init()
        {
            try
            {
                Model.Recept recept = await _ReceptService.GetById<Model.Recept>(RecipeId);

                var oldPregledi = await _ReceptPregledService.GetById<Model.ReceptPregled>(recept.ReceptPregledId);

                await _ReceptPregledService.Update<Model.ReceptPregled>(oldPregledi.Id, new Model.Requests.ReceptPregledUpsertRequest
                {
                    BrojPregleda = oldPregledi.BrojPregleda++
                });

                var ratings = await _RatingService.Get<List<Model.Rating>>(new Model.Requests.RatingSearchRequest { ReceptId = RecipeId });
                int sum = 0;
                foreach (Model.Rating rating in ratings)
                {
                    sum += (int)rating.Mark + 1;
                }
                txtStarBox.Text = createStars(ratings.Count != 0 ? (sum / ratings.Count) : 0) + " Stars!";

                Model.Kategorija kat = await _KategorijeService.GetById<Model.Kategorija>(recept.KategorijaId);
                Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(recept.ImageResourceId);
                img_profile.ImageSource = imageResource != null ? new ImageService().arrayToImageSource(imageResource.ImageByteValue) : new ImageService().uriToImageSource("/Images/logo.png");

                txtBookName.Text = this.KnjigaNaziv;
                txtRecipeName.Text = recept.Naziv;
                txtCategoryName.Text = kat.Naziv;
                txtEffort.Text = recept.DuzinaPripreme.ToString();
                txtDescription.AppendText(recept.Deskripcija);
                KnjigaId = recept.KnjigaRecepataId;

                Sastojci.Clear();

                var lista = await _ReceptSastojciService.Get<List<Model.ReceptSastojak>>(new Model.Requests.ReceptSastojakSearchRequest
                {
                    ReceptId = RecipeId
                });

                foreach (var sastojak in lista)
                {
                    Sastojci.Add(sastojak.Kolicina + " Grams of " + sastojak.Naziv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception: " + ex.Message, "Error", MessageBoxButton.OK);
            }

        }

        private string createStars(int mark)
        {
            switch (mark)
            {
                case 2:
                    return "\u2605 \u2605";
                case 3:
                    return "\u2605 \u2605 \u2605";
                case 4:
                    return "\u2605 \u2605 \u2605 \u2605";
                case 5:
                    return "\u2605 \u2605 \u2605 \u2605 \u2605";
            };
            return "\u2605";
        }

        private void txt_AddRatingClick(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new AddRating(RecipeId));
        }

        private void txt_ViewRatingsClick(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new ViewUserRatings(RecipeId));
        }
        private void txt_UpdateRecipeClick(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new AddRecipe(KnjigaId, true, RecipeId));
        }
        private void txt_DeleteRecipeClick(object sender, RoutedEventArgs e)
        {
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
