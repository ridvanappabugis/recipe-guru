using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using recipe_guru.Mobile.Converters;
using recipe_guru.Mobile.Models;
using recipe_guru.Mobile.Services;
using recipe_guru.Mobile.ViewModels;
using Xamarin.Forms;

namespace recipe_guru.Mobile.Views
{
    public partial class AddReceptPage : ContentPage
    {
        private readonly APIService _ReceptService = new APIService("Recept");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");
        private readonly APIService _ReceptSastojakService = new APIService("ReceptSastojak");
        private readonly APIService _ReceptPregledService = new APIService("ReceptPregled");


        private int KnjigaRecepataId { get; set; }
        private byte[] imageByteArray { get; set; }

        public AddReceptViewModel model = null;

        public AddReceptPage(int KnjigaRecepataId)
        {
            InitializeComponent();
            this.KnjigaRecepataId = KnjigaRecepataId;
            BindingContext = model = new AddReceptViewModel(KnjigaRecepataId);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
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
                if (string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Description.Text) || model.Sastojci.Count == 0 || KategorijaPicker.SelectedIndex == -1 || string.IsNullOrWhiteSpace(Effort.Text))
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
                var pregeldi = await _ReceptPregledService.Insert<Model.ReceptPregled>(new Model.Requests.ReceptPregledUpsertRequest
                {
                    BrojPregleda = 0
                });

                var recept = await _ReceptService.Insert<Model.Recept>(new Model.Requests.ReceptUpsertRequest
                {
                    KnjigaRecepataId = KnjigaRecepataId,
                    ImageResourceId = imageResourceId,
                    DuzinaPripreme = Convert.ToInt32(Effort.Text),
                    KategorijaId = ((Model.Kategorija)KategorijaPicker.SelectedItem).Id,
                    Naziv = Name.Text,
                    Public = true,
                    Deskripcija = Description.Text,
                    ReceptPregledId = pregeldi.Id
                });

                foreach (var sastojak in model.Sastojci)
                {
                    await _ReceptSastojakService.Insert<Model.ReceptSastojak>(new Model.Requests.ReceptSastojakUpsertRequest
                    {
                        ReceptId = recept.Id,
                        Kolicina = sastojak.Ammount + "",
                        Naziv = sastojak.Naziv
                    });
                }

                await Application.Current.MainPage.DisplayAlert("Succesfull", "The Recepie has been added.", "OK");
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.InnerException.ToString(), "Try again");
                throw;
            }
        }

        void OnAddIngredientButtonClicked(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(IngredientAmmount.Text) && !string.IsNullOrWhiteSpace(IngredientName.Text))
            {
                model.Sastojci.Add(new ReceptSastojakListViewItem {
                    Ammount = Convert.ToInt32(IngredientAmmount.Text),
                    Naziv = IngredientName.Text,
                    PuniNaziv = IngredientAmmount.Text + " Grams of " + IngredientName.Text
                });
                IngredientAmmount.Text = null;
                IngredientName.Text = null;
            }
        }
    }
}
