using recipe_guru.WPFDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for ViewUserRatings.xaml
    /// </summary>
    public partial class ViewUserRatings : Page
    {
        public ViewUserRatings(int ReceptId)
        {
            InitializeComponent();
            this.receptId = ReceptId;
        }

        private readonly APIService _RatingService = new APIService("Rating");
        private readonly APIService _KorisnikService = new APIService("Korisnici");

        public ObservableCollection<RatingListViewItem> Ratings { get; set; } = new ObservableCollection<RatingListViewItem>();

        public int receptId { get; set; }
        protected async void loaded_handler(object sender, RoutedEventArgs e)
        {
            Init();
            ListViewRatings.ItemsSource = Ratings;
        }

        private async void Init()
        {
            try
            {
                var ratings = await _RatingService.Get<List<Model.Rating>>(new Model.Requests.RatingSearchRequest { ReceptId = receptId });

                foreach (var rating in ratings)
                {
                    var korisnik = await _KorisnikService.GetById<Model.Korisnik>(rating.KorisnikId);

                    Ratings.Add(new RatingListViewItem
                    {
                        Stars = createStars(rating.Mark),
                        Comment = rating.Comment,
                        Date = rating.InsertTime.ToShortDateString(),
                        User = korisnik.Ime + " " + korisnik.Prezime
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception: " + ex.Message, "Error", MessageBoxButton.OK);
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
