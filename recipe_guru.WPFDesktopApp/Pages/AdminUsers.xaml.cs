using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using recipe_guru.Model;
using recipe_guru.Model.ReportModels;
using recipe_guru.Model.Requests;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for AdminUsers.xaml
    /// </summary>
    public partial class AdminUsers : Page
    {

        APIService _serviceUser = new APIService("Korisnici");
        APIService _serviceUserType = new APIService("Uloge");

        ObservableCollection<frmUserSearchVM> vm = new ObservableCollection<frmUserSearchVM>();

        public AdminUsers()
        {
            InitializeComponent();
        }

        private async void filterEvent(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private async Task LoadUsers()
        {
            vm.Clear();
            KorisniciSearchRequest request = new KorisniciSearchRequest
            {
                KorisnickoIme = txtSearch.Text
            };

            var list = await _serviceUser.GetAll<List<Korisnik>>(request);
            foreach (var item in list)
            {
                var uloga = await _serviceUserType.GetById<Model.Uloga>(item.UlogaId);
                frmUserSearchVM userSearch = new frmUserSearchVM
                {
                    Id = item.Id,
                    Email = item.Email,
                    FirstName = item.Ime,
                    LastName = item.Prezime,
                    Phone = item.Telefon,
                    Username = item.KorisnickoIme,
                    UserType = uloga.Naziv.ToString()
                };
                vm.Add(userSearch);
            }

            dgvUser.AutoGenerateColumns = false;
            dgvUser.ItemsSource = vm;
            CollectionViewSource.GetDefaultView(vm).Refresh();
        }

        private async void frmUserSearch_Load(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private async void CreateReport(object sender, EventArgs e)
        {
            new ReportingService().CreateUsersPDF(vm.ToList());

        }
    }
}
