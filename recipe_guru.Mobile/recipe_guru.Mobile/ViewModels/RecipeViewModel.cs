using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using recipe_guru.Mobile.Converters;
using recipe_guru.Mobile.Views;
using Xamarin.Forms;

namespace recipe_guru.Mobile.ViewModels
{
    public class RecipeViewModel : BaseViewModel
    {
        private readonly APIService _ReceptService = new APIService("Recept");
        private readonly APIService _ReceptSastojciService = new APIService("ReceptSastojak");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");
        private readonly APIService _KategorijeService = new APIService("Kategorije");
        private readonly APIService _RatingService = new APIService("Rating");

        public ObservableCollection<string> Sastojci { get; set; } = new ObservableCollection<string>();

        public int receptId { get; set; }
        public ImageSource imageSource;
        public string nazivRecepta = string.Empty;
        public string kategorija = string.Empty;
        public string duzinaPripreme = string.Empty; 
        public string rating = string.Empty;
        public string description = string.Empty;

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { SetProperty(ref imageSource, value); }
        }
        public string NazivRecepta
        {
            get { return nazivRecepta; }
            set { SetProperty(ref nazivRecepta, value); }
        }
        public string Kategorija
        {
            get { return kategorija; }
            set { SetProperty(ref kategorija, value); }
        }
        public string DuzinaPripreme
        {
            get { return duzinaPripreme; }
            set { SetProperty(ref duzinaPripreme, value); }
        }
        public string Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public RecipeViewModel(int receptId)
        {
            this.receptId = receptId;
        }

        internal async Task Init()
        {
            try
            {
                Model.Recept recept = await _ReceptService.GetById<Model.Recept>(receptId);

                var ratings = await _RatingService.Get<List<Model.Rating>>(new Model.Requests.RatingSearchRequest { ReceptId = receptId });
                int sum = 0;
                foreach(Model.Rating rating in ratings) {
                    sum += (int)rating.Mark;
                }
                Rating = createStars(ratings.Count!=0 ? (sum/ratings.Count) : 0) + " Stars!";

                Model.Kategorija kat = await _KategorijeService.GetById<Model.Kategorija>(recept.KategorijaId);
                Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(recept.ImageResouceId);
                ImageSource = imageResource != null ? new ImageConverter().Convert(imageResource.ImageByteValue) : "notfound.png";

                NazivRecepta = recept.Naziv;
                Kategorija = kat.Naziv;
                DuzinaPripreme = recept.DuzinaPripreme + " minutes";
                Description = "svasta nesto.";

                Sastojci.Clear();

                var lista = await _ReceptSastojciService.Get<List<Model.ReceptSastojak>>(new Model.Requests.ReceptSastojakSearchRequest
                {
                    ReceptId = receptId
                });

                foreach (var sastojak in lista)
                {
                    Sastojci.Add(sastojak.Kolicina + sastojak.Naziv);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }

        }

        private string createStars(int mark)
        {
            switch (mark)
            {
                case 2:
                    return "\u2605 \u2605";
                case 3:
                    return "\u2605 \u2605 \u2605";
                case 4:
                    return "\u2605 \u2605 \u2605 \u2605";
                case 5:
                    return "\u2605 \u2605 \u2605 \u2605 \u2605";
            };
            return "\u2605";
        }
    }
}