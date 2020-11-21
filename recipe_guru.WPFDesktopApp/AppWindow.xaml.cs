using recipe_guru.WPFDesktopApp.Pages;
using System.Windows;
using System.Windows.Navigation;


namespace recipe_guru.WPFDesktopApp
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        private bool btnDisabled = false;

        public AppWindow()
        {
            InitializeComponent();
            _mainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            _mainFrame.Navigate(new RecipeBooks());

        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new Search());
        }

        private async void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new UserProfile());

        }

        private async void btnRecipeBook_Click(object sender, RoutedEventArgs e)
        {
            clearHistory();
            _mainFrame.Navigate(new RecipeBooks());

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

        private void clearHistory()
        {
            if (_mainFrame.CanGoBack)
            {
                _mainFrame.RemoveBackEntry();
            }
        }
    }
}
