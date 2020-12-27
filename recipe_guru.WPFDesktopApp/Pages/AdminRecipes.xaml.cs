using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using recipe_guru.Model.ReportModels;
using recipe_guru.Model.Requests;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for AdminRecipes.xaml
    /// </summary>
    public partial class AdminRecipes : Page
    {

        APIService _serviceUser = new APIService("Korisnici");
        APIService _serviceKnjigaRecepata = new APIService("KnjigaRecepata");
        APIService _serviceRecipes = new APIService("Recept");
        APIService _serviceRating = new APIService("Rating");
        APIService _serviceBrojPregleda = new APIService("ReceptPregled");
        APIService _serviceKategorije = new APIService("Kategorije");

        public AdminRecipes()
        {
            InitializeComponent();
        }

        private async void frmRecipes_Load(object sender, EventArgs e)
        {
            refresh();
        }

        ObservableCollection<frmRecipesUsersVM> vm = new ObservableCollection<frmRecipesUsersVM>();


        private async void refresh()
        {
            vm.Clear();

            var listKnjiga = await _serviceKnjigaRecepata.GetAll<List<Model.KnjigaRecepata>>(new KnjigaRecepataSearchRequest ());

            foreach (var knjiga in listKnjiga)
            {
                var list = await _serviceRecipes.GetAll<List<Model.Recept>>(new ReceptSearchRequest
                {
                    KnjigaRecepataId = knjiga.Id,
                    Naziv = txtSearch.Text
                });

                foreach (var recept in list)
                {
                    List<int> avg = new List<int>();
                    int brojPregleda = 0;
                    var ratings = await _serviceRating.GetAll<List<Model.Rating>>(new RatingSearchRequest { ReceptId = recept.Id });
                    var pregled = await _serviceBrojPregleda.GetById<Model.ReceptPregled>(recept.ReceptPregledId);
                    var kategorija = await _serviceKategorije.GetById<Model.Kategorija>(recept.KategorijaId);

                    vm.Add(new frmRecipesUsersVM
                    {
                        Id = recept.Id,
                        Naziv = recept.Naziv,
                        Description = recept.Deskripcija,
                        RecipeBook = knjiga.Naziv,
                        AverageRating = (int)ratings.Average(x => (int)x.Mark) + 1,
                        NumberOfRatings = ratings.Count(),
                        NumberOfViews = pregled.BrojPregleda,
                        Kategorija = kategorija.Naziv
                    });

                }
            }

            dgvRecipes.AutoGenerateColumns = false;
            dgvRecipes.ItemsSource = vm;
            CollectionViewSource.GetDefaultView(vm).Refresh();
        }

        private async void deleteRecipe(object sender, EventArgs e)
        {
            try
            {

                MessageBoxResult result = MessageBox.Show("This will delete the recipe. Are you sure?", "Warning", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    Button button = sender as Button;
                    await _serviceRecipes.Delete(((button.DataContext as frmRecipesUsersVM).Id));
                }

                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception: " + ex.Message, "Error", MessageBoxButton.OK);
            }

        }

        private void filterEvent(object sender, EventArgs e)
        {
            refresh();
        }

        private async void CreateReport(object sender, EventArgs e)
        {
            new ReportingService().CreateRecipesPDF(vm.ToList());
        }
    }
}
