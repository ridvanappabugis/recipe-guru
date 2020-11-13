using recipe_guru.Model;
using recipe_guru.Model.Requests;
using System;
using System.Collections.Generic;
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

namespace recipe_guru.WPFDesktop.Pages
{
    /// <summary>
    /// Interaction logic for UpdateUserImage.xaml
    /// </summary>
    public partial class UpdateUserImage : Page
    {
        public UpdateUserImage()
        {
            InitializeComponent();
        }

        private readonly APIService _ImageResourceService = new APIService("ImageResource");
        private readonly APIService _serviceUser = new APIService("Korisnici");

        private bool updatedImage = false;

        private void btnPickImage_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new ImageService().loadImage();

            if (image != null)
            {
                updatedImage = true;
                img_UserImage.ImageSource = image;

            }
        }

        protected override async void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (APIService.User.ImageResourceId != 0)
            {
                Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(APIService.User.ImageResourceId);

                img_UserImage.ImageSource = new ImageService().arrayToImageSource(imageResource.ImageByteValue);
            }
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (updatedImage == false)
            {
                MessageBox.Show("Please choose an image", "Warning", MessageBoxButton.OK);
                return;
            }

            try
            {

                byte[] data = new ImageService().bitmapToArray(img_UserImage.ImageSource as BitmapImage);

                int? imageResourceId = null;
                if (img_UserImage.ImageSource != null)
                {
                    Model.ImageResource imageResource = await _ImageResourceService.Insert<Model.ImageResource>(new Model.Requests.ImageResourceUpsertRequest
                    {
                        ImageByteValue = data
                    });
                    imageResourceId = imageResource.Id;
                }


                var user = await _serviceUser.Update<Korisnik>(APIService.UserId, new KorisniciInsertRequest
                {
                    KorisnickoIme = APIService.User.KorisnickoIme,
                    Ime = APIService.User.Ime,
                    Prezime = APIService.User.Prezime,
                    Email = APIService.User.Email,
                    Telefon = APIService.User.Telefon,
                    UlogaId = 2,
                    Deskripcija = APIService.User.Deskripcija,
                    ImageResourceId = imageResourceId
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
                throw;
            }

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.GoBack();
        }
    }
}
