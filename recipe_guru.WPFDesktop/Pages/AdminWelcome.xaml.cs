using System.Windows.Controls;
using recipe_guru.WPFDesktop;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for AdminWelcome.xaml
    /// </summary>
    public partial class AdminWelcome : Page
    {
        public AdminWelcome()
        {
            InitializeComponent();
            txtAdminName.Text = APIService.User.Ime + " " + APIService.User.Prezime;
        }
    }
}
