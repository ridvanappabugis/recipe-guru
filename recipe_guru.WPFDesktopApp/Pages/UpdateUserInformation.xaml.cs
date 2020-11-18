using recipe_guru.Model;
using recipe_guru.Model.Requests;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for UpdateUserInformation.xaml
    /// </summary>
    public partial class UpdateUserInformation : Page
    {
        public UpdateUserInformation()
        {
            InitializeComponent();
            txtUserName.Text = APIService.User.KorisnickoIme;
            txtFirstName.Text = APIService.User.Ime;
            txtLastName.Text = APIService.User.Prezime;
            txtEmail.Text = APIService.User.Email;
            txtPhoneNumber.Text = APIService.User.Telefon;
        }

        private readonly APIService _serviceUser = new APIService("Korisnici");

        async void Update()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
                   string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text)
                   || string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    MessageBox.Show("All Fields are required.", "Error", MessageBoxButton.OK);
                    return;
                }

                if (txtUserName.Text.Length < 4)
                {
                    MessageBox.Show("User Name must have 4 characters.", "Error", MessageBoxButton.OK);
                    return;
                }

                var listUsers = await _serviceUser.Get<List<Model.Korisnik>>(null);
                foreach (var item in listUsers)
                {
                    if (txtUserName.Text == item.KorisnickoIme && APIService.Username != item.KorisnickoIme)
                    {
                        MessageBox.Show("User Name already exists.", "Error", MessageBoxButton.OK);
                        return;
                    }
                }

                var newUser = await _serviceUser.Update<Korisnik>(APIService.UserId, new KorisniciInsertRequest
                {
                    KorisnickoIme = txtUserName.Text,
                    Ime = txtFirstName.Text,
                    Prezime = txtLastName.Text,
                    Email = txtEmail.Text,
                    Telefon = txtPhoneNumber.Text,
                    UlogaId = 2,
                    Deskripcija = "Loer"
                });


                if (newUser == default(Korisnik))
                    return;

                APIService.Password = txtUserName.Text;
                MessageBox.Show("Information has changed, please login to confirm changes.", "Success", MessageBoxButton.OK);
                LoginWindow mnw = new LoginWindow();
                Window.GetWindow(this).Close();
                mnw.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception occured: " + ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.GoBack();
        }
    }
}
