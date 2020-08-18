using System;
using System.Collections.Generic;
using recipe_guru.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recipe_guru.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRatingPage : ContentPage
    {
        public int receptid { get; set; }

        public List<string> ratings { get; set; } = new List<string> { "\u2605", "\u2605 \u2605", "\u2605 \u2605 \u2605", "\u2605 \u2605 \u2605 \u2605", "\u2605 \u2605 \u2605 \u2605 \u2605" };

        private readonly APIService _RatingService = new APIService("Rating");
        private readonly APIService _KorisnikService = new APIService("Korisnici");

        public AddRatingPage(int ReceptId)
        {
            InitializeComponent();
            this.receptid = ReceptId;
            picker.ItemsSource = ratings;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Comment.Text) || picker.SelectedIndex == -1)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "All fields are required.", "Try again");
                    return;
                }

                await _RatingService.Insert<Model.Rating>(new Model.Requests.RatingUpsertRequest {
                    ReceptId = receptid,
                    KorisnikId = APIService.UserId,
                    Comment = Comment.Text,
                    InsertTime = DateTime.Now,
                    Mark = createStars(picker.SelectedItem.ToString())
                });

                await Application.Current.MainPage.DisplayAlert("Succesfull", "Review Added.", "OK");
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Try again");
            }
        }

        private Model.RatingMark createStars(string mark)
        {
            switch (mark)
            {
                case "\u2605 \u2605":
                    return Model.RatingMark.TWO_STAR;
                case "\u2605 \u2605 \u2605":
                    return Model.RatingMark.THREE_STAR;
                case "\u2605 \u2605 \u2605 \u2605":
                    return Model.RatingMark.FOUR_STAR;
                case "\u2605 \u2605 \u2605 \u2605 \u2605":
                    return Model.RatingMark.FIVE_STAR;
            };
            return Model.RatingMark.ONE_STAR;
        }
    }
}

