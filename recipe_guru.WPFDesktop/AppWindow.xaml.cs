using recipe_guru.WPFDesktop.Pages;
using System.Windows;
using System.Windows.Navigation;


namespace recipe_guru.WPFDesktop
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public AppWindow()
        {
            InitializeComponent();
            _mainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            _mainFrame.Navigate(new Home());

        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new Search());

        }

        private async void btnHome_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new Home());
        }

        private async void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new UserProfile());

        }

        private async void btnRecipeBook_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new RecipeBook());

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void clearHistory()
        {
            if (_mainFrame.CanGoBack)
            {
                _mainFrame.RemoveBackEntry();
            }
        }
    }
}
