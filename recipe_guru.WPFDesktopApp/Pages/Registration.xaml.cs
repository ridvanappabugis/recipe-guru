using recipe_guru.Model;
using recipe_guru.Model.Requests;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private readonly APIService _serviceUser = new APIService("Korisnici");

        async void Register()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
                  string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text)
                  || string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Password) || string.IsNullOrWhiteSpace(txtConfirmPassword.Password))
                {
                    MessageBox.Show("All Fields are required.", "Error", MessageBoxButton.OK);
                    return;
                }
                if (!Regex.IsMatch(txtPhoneNumber.Text, @"^\d+$"))
                {
                    MessageBox.Show("Phone Number must be numeric.", "Error", MessageBoxButton.OK);
                    return;
                }
                if (!IsValid(txtEmail.Text))
                {
                    MessageBox.Show("Invalid Email format.", "Error", MessageBoxButton.OK);
                    return;
                }
                if (txtPassword.Password != txtConfirmPassword.Password)
                {
                    MessageBox.Show("Passwords do not match! Try again.", "Error", MessageBoxButton.OK);
                    return;
                }
                var listUsers = await _serviceUser.Get<List<Model.Korisnik>>(null);
                foreach (var item in listUsers)
                {
                    if (txtUserName.Text == item.KorisnickoIme)
                    {
                        MessageBox.Show("Username already exists.", "Error", MessageBoxButton.OK);
                        return;
                    }

                    if (txtEmail.Text == item.Email)
                    {
                        MessageBox.Show("Email already exists.", "Error", MessageBoxButton.OK);
                        return;
                    }
                }
                var newUser = await _serviceUser.Insert<Model.Korisnik>(new KorisniciInsertRequest
                {
                    Ime = txtFirstName.Text,
                    Prezime = txtLastName.Text,
                    Email = txtEmail.Text,
                    Telefon = txtPhoneNumber.Text,
                    Password = txtPassword.Password,
                    PasswordPotvrda = txtPassword.Password,
                    KorisnickoIme = txtUserName.Text,
                    UlogaId = 2
                });

                if (newUser == default(Korisnik))
                    return;

                MessageBox.Show("Registration Successfull! Please Login.", "Info", MessageBoxButton.OK);

                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception: " + ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.GoBack();
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
