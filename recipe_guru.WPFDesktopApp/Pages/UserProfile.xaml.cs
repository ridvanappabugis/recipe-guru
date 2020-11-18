using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Page
    {
        private readonly APIService _serviceUser = new APIService("Korisnik");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");

        public UserProfile()
        {
            InitializeComponent();
            txtUsername.Text = APIService.User.KorisnickoIme;
            txtPersonName.Text = APIService.User.Ime + " " + APIService.User.Prezime;
            txtEmail.Text = APIService.User.Email;
            txtPhoneNumber.Text = APIService.User.Telefon;
            txtDescription.AppendText(APIService.User.Deskripcija);
        }

        protected override async void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (APIService.User.ImageResourceId != 0)
            {
                Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(APIService.User.ImageResourceId);

                img_profile.ImageSource = new ImageService().arrayToImageSource(imageResource.ImageByteValue);
            }
        }

        private void txt_SettingsClick(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new UpdateUserInformation());
        }
        private void txt_PasswordChangeClick(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new UpdateUserPassword());
        }
        private void txt_ProfileChangeClick(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new UpdateUserImage());
        }

    }
}
