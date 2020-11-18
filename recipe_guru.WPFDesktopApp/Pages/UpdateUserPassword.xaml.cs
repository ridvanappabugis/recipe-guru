using recipe_guru.Model;
using recipe_guru.Model.Requests;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for UpdateUserPassword.xaml
    /// </summary>
    public partial class UpdateUserPassword : Page
    {
        public UpdateUserPassword()
        {
            InitializeComponent();
        }

        private readonly APIService _serviceUser = new APIService("Korisnici");
        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCurrentPassword.Password != APIService.Password)
                {
                    MessageBox.Show("Wrong Current Password.", "Error", MessageBoxButton.OK);
                    return;
                }

                if (txtPassword.Password != txtConfirmPassword.Password)
                {
                    MessageBox.Show("New Password and Confirmation Password do not match.", "Error", MessageBoxButton.OK);
                    return;
                }

                if (txtPassword.Password.Length < 4)
                {
                    MessageBox.Show("Password must have a minimum of 4 characters.", "Error", MessageBoxButton.OK);
                    return;
                }

                await _serviceUser.Update<Korisnik>(APIService.UserId, new KorisniciInsertRequest
                {
                    Password = txtPassword.Password,
                    PasswordPotvrda = txtConfirmPassword.Password
                });

                APIService.Password = null;
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
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.GoBack();
        }
    }
}
