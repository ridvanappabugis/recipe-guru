using System.Windows;
using System.Windows.Navigation;
using recipe_guru.WPFDesktopApp;
using recipe_guru.WPFDesktopApp.Pages;

namespace recipe_guru.WPFDesktopApp
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private bool btnDisabled = false;
        public AdminWindow()
        {
            InitializeComponent();
            _mainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            _mainFrame.Navigate(new AdminWelcome());
        }

        private async void btnUser_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new AdminUsers());
        }

        private async void btnRecipes_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new AdminRecipes());
        }

        private async void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new AdminCategories());

        }

        private async void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new UserProfile());

        }

        private async void btnAdmins_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new AdminAddAdmin());

        }

        private void clearHistory()
        {
            if (_mainFrame.CanGoBack)
            {
                _mainFrame.RemoveBackEntry();
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (btnDisabled)
            {
                return;
            }
            btnDisabled = true;

            LoginWindow mnw = new LoginWindow();
            Window.GetWindow(this).Close();
            mnw.ShowDialog();
            btnDisabled = false;
        }
    }
}
