using recipe_guru.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for AddRecipeBook.xaml
    /// </summary>
    public partial class AddRecipeBook : Page
    {
        public AddRecipeBook()
        {
            InitializeComponent();
        }

        private readonly APIService _ImageResourceService = new APIService("ImageResource");
        private readonly APIService _KnjigeRecepataService = new APIService("KnjigaRecepata");

        private bool updatedImage = false;

        private void btnPickImage_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new ImageService().loadImage();

            if (image != null)
            {
                updatedImage = true;
                img_BookImage.ImageSource = image;

            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (updatedImage == false)
            {
                MessageBox.Show("Please choose an image", "Warning", MessageBoxButton.OK);
                return;
            }

            if (txtBookName.Text == null || txtBookDescription.Text.Length == 0 || txtBookDescription.Text == null || txtBookName.Text.Length == 0)
            {
                MessageBox.Show("All fields are required!", "Warning", MessageBoxButton.OK);
                return;
            }

            if (txtBookName.Text.Length > 25)
            {
                MessageBox.Show("Book Name must be less than 25 characters long!", "Warning", MessageBoxButton.OK);
                return;
            }

            if (txtBookDescription.Text.Length > 40)
            {
                MessageBox.Show("Book Description must be less than 40 characters long!", "Warning", MessageBoxButton.OK);
                return;
            }

            try
            {

                byte[] data = new ImageService().bitmapToArray(img_BookImage.ImageSource as BitmapImage);

                int? imageResourceId = null;
                if (img_BookImage.ImageSource != null)
                {
                    Model.ImageResource imageResource = await _ImageResourceService.Insert<Model.ImageResource>(new Model.Requests.ImageResourceUpsertRequest
                    {
                        ImageByteValue = data
                    });
                    imageResourceId = imageResource.Id;
                }

                var book = await _KnjigeRecepataService.Insert<KnjigaRecepata>(new Model.Requests.KnjigaRecepataUpsertRequest
                {
                    Naziv = txtBookName.Text,
                    Deskripcija = txtBookDescription.Text,
                    ImageResourceId = imageResourceId,
                    Public = true,
                    KorisnikId = APIService.UserId
                });

                MessageBox.Show("Added book succesfully.", "Success", MessageBoxButton.OK);
                NavigationService.Navigate(new RecipeBooks());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception occured: " + ex.Message, "Error", MessageBoxButton.OK);
                throw;
            }

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RecipeBooks());
        }
    }
}
