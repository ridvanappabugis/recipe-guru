using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using recipe_guru.Mobile.Models;
using Xamarin.Forms;

namespace recipe_guru.Mobile.ViewModels
{
    public class RatingsViewModel : BaseViewModel
    {
        private readonly APIService _RatingService = new APIService("Rating");
        private readonly APIService _KorisnikService = new APIService("Korisnici");

        public ObservableCollection<RatingListViewItem> Ratings { get; set; } = new ObservableCollection<RatingListViewItem>();

        public int receptId { get; set; }
        public string NazivRecepta { get; set; }

        public RatingsViewModel(int receptId, string Naziv)
        {
            this.receptId = receptId;
            this.NazivRecepta = Naziv;
        }

        internal async Task Init()
        {
            try
            {
                var ratings = await _RatingService.Get<List<Model.Rating>>(new Model.Requests.RatingSearchRequest { ReceptId = receptId });

                foreach (var rating in ratings)
                {
                    var korisnik = await _KorisnikService.GetById<Model.Korisnik>(rating.KorisnikId);

                    Ratings.Add(new RatingListViewItem {
                        Stars = createStars(rating.Mark),
                        Comment = rating.Comment,
                        Date = rating.InsertTime.ToShortDateString(),
                        User = korisnik.Ime + " " + korisnik.Prezime
                    });
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }

        }

        private string createStars(Model.RatingMark mark)
        {
            switch (mark)
            {
                case Model.RatingMark.TWO_STAR:
                    return "\u2605 \u2605";
                case Model.RatingMark.THREE_STAR:
                    return "\u2605 \u2605 \u2605";
                case Model.RatingMark.FOUR_STAR:
                    return "\u2605 \u2605 \u2605 \u2605";
                case Model.RatingMark.FIVE_STAR:
                    return "\u2605 \u2605 \u2605 \u2605 \u2605";
            };
            return "\u2605";
        }
    }
}
