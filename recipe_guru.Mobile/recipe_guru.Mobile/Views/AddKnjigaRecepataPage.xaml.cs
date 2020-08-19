using System;
using System.Collections.Generic;
using System.IO;
using recipe_guru.Mobile.Converters;
using recipe_guru.Mobile.Services;
using Xamarin.Forms;

namespace recipe_guru.Mobile.Views
{
    public partial class AddKnjigaRecepataPage : ContentPage
    {

        private readonly APIService _KnjigaRecepataService = new APIService("KnjigaRecepata");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");

        private byte[] imageByteArray { get; set; }

        public AddKnjigaRecepataPage()
        {
            InitializeComponent();
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();

            if (stream != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    imageByteArray = memoryStream.ToArray();
                    image.Source = new ImageConverter().Convert(imageByteArray);
                }
            }

            (sender as Button).IsEnabled = true;
        }

        async void OnSaveButtonClicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Description.Text))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Fields are required.", "Try again");
                    return;
                }

                int? imageResourceId = null;
                if (imageByteArray != null)
                {
                    Model.ImageResource imageResource = await _ImageResourceService.Insert<Model.ImageResource>(new Model.Requests.ImageResourceUpsertRequest
                    {
                        ImageByteValue = imageByteArray
                    });
                    imageResourceId = imageResource.Id;
                }

                await _KnjigaRecepataService.Insert<Model.KnjigaRecepata>(new Model.Requests.KnjigaRecepataUpsertRequest {
                    KorisnikId = APIService.UserId,
                    Deskripcija = Description.Text,
                    Naziv = Name.Text,
                    Public = true,
                    ImageResourceId = imageResourceId
                });

                await Application.Current.MainPage.DisplayAlert("Succesfull", "The Book has been added.", "OK");
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.InnerException.ToString(), "Try again");
                throw;
            }
        }
    }
}
