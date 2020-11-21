using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using recipe_guru.Model.ReportModels;
using recipe_guru.Model.Requests;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for AdminCategories.xaml
    /// </summary>
    public partial class AdminCategories : Page
    {
        APIService _serviceKategorije = new APIService("Kategorije");
        APIService _serviceRecept = new APIService("Recept");
        APIService _serviceRating = new APIService("Rating");
        APIService _serviceBrojPregleda = new APIService("ReceptPregled");

        ObservableCollection<frmCategoriesVM> vm = new ObservableCollection<frmCategoriesVM>();

        public AdminCategories()
        {
            InitializeComponent();
        }

        private async void addCategory_Click(object sender, EventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new AdminAddCategory());
        }

        private async Task LoadCategories()
        {
            vm.Clear();

            var list = await _serviceKategorije.GetAll<List<Model.Kategorija>>(null);
            foreach (var item in list)
            {
                var recepti = await _serviceRecept.GetAll<List<Model.Recept>>(new ReceptSearchRequest
                {
                    KategorijaId = item.Id
                });

                List<int> avg = new List<int>();
                int brojPregleda = 0;
                foreach (var recept in recepti)
                {
                    var ratings = await _serviceRating.GetAll<List<Model.Rating>>(new RatingSearchRequest { ReceptId = recept.Id });
                    var pregled = await _serviceBrojPregleda.GetById<Model.ReceptPregled>(recept.ReceptPregledId);

                    avg.Add((int)ratings.Average(x => (int)x.Mark));
                    brojPregleda = pregled.BrojPregleda + brojPregleda;
                }

                frmCategoriesVM categoryStatistics = new frmCategoriesVM
                {
                    Id = item.Id,
                    Naziv = item.Naziv,
                    AvgRating = avg.Count() != 0 ? (int)avg.Average(x => x) + 1 : 0,
                    BrojPregleda = brojPregleda,
                    BrojRecepata = recepti.Count()
                };

                vm.Add(categoryStatistics);
            }

            dSgCategories.AutoGenerateColumns = false;
            dSgCategories.ItemsSource = vm;
            CollectionViewSource.GetDefaultView(vm).Refresh();
        }

        private async void loaded_handler(object sender, EventArgs e)
        {
            await LoadCategories();
        }

        private async void deleteCategory(object sender, EventArgs e)
        {
            try
            {

             

                MessageBoxResult result = MessageBox.Show("This will delete the category and all recipes with it. Are you sure?", "Warning", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    Button button = sender as Button;
                    await _serviceKategorije.Delete(((button.DataContext as frmCategoriesVM).Id));
                }

                await LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception: " + ex.Message, "Error", MessageBoxButton.OK);
            }

        }

        private async void CreateReport(object sender, EventArgs e)
        {
            new ReportingService().CreateCategoriesPDF(vm.ToList());

        }
    }
}
