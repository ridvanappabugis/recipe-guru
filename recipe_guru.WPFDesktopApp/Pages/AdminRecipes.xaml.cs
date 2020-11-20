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
            var listKnjiga = await _serviceKnjigaRecepata.GetAll<List<Model.KnjigaRecepata>>(new KnjigaRecepataSearchRequest ());

            List<frmRecipesUsersVM> vm = new List<frmRecipesUsersVM>();

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

                    vm.Add(new frmRecipesUsersVM
                    {
                        Id = recept.Id,
                        Naziv = recept.Naziv,
                        Description = recept.Deskripcija,
                        RecipeBook = knjiga.Naziv,
                        AverageRating = (int)ratings.Average(x => (int)x.Mark) + 1,
                        NumberOfRatings = ratings.Count(),
                        NumberOfViews = pregled.BrojPregleda
                    });

                }
            }

            dgvRecipes.AutoGenerateColumns = false;
            dgvRecipes.ItemsSource = vm;
            CollectionViewSource.GetDefaultView(vm).Refresh();
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
