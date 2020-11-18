using recipe_guru.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
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
using recipe_guru.WPFDesktopApp;

namespace recipe_guru.WPFDesktop.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private readonly APIService _serviceUser = new APIService("Korisnici");
        private readonly APIService _testService = new APIService("Kategorije");

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == null || txtPassword.Password == null)
            {
                MessageBox.Show("Login Fields are required.", "Error", MessageBoxButton.OK);
            }

            APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Password;

            try
            {
                await _testService.Get<dynamic>(null);
                List<Model.Korisnik> temp = await _serviceUser.Get<List<Model.Korisnik>>(new KorisniciSearchRequest
                {
                    KorisnickoIme = txtUsername.Text
                });
                APIService.User = temp.FirstOrDefault();
                APIService.UserId = temp.Select(x => x.Id).FirstOrDefault();

                if (APIService.User.UlogaId == 1)
                {
                    AdminWindow mnw = new AdminWindow();
                    Window.GetWindow(this).Close();
                    mnw.ShowDialog();
                }
                else
                {
                    AppWindow mnw = new AppWindow();
                    Window.GetWindow(this).Close();
                    mnw.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Registration());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
