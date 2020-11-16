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
    /// Interaction logic for AddRating.xaml
    /// </summary>
    public partial class AddRating : Page
    {
        private int RecipeId;

        private readonly APIService _RatingService = new APIService("Rating");
        public List<string> ratings { get; set; } = new List<string> { "\u2605", "\u2605 \u2605", "\u2605 \u2605 \u2605", "\u2605 \u2605 \u2605 \u2605", "\u2605 \u2605 \u2605 \u2605 \u2605" };


        public AddRating(int RecipeId)
        {
            InitializeComponent();
            this.RecipeId = RecipeId;
        }

        protected async void loaded_handler(object sender, RoutedEventArgs e)
        {
            selectedRatingFilter.ItemsSource = ratings;
            selectedRatingFilter.SelectedItem = null;
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtComment.Text) || selectedRatingFilter.SelectedIndex == -1)
                {
                    MessageBox.Show("All fields are required", "Error", MessageBoxButton.OK);
                    return;
                }

                await _RatingService.Insert<Model.Rating>(new Model.Requests.RatingUpsertRequest
                {
                    ReceptId = RecipeId,
                    KorisnikId = APIService.UserId,
                    Comment = txtComment.Text,
                    InsertTime = DateTime.Now,
                    Mark = createStars(selectedRatingFilter.Text)
                });

                MessageBox.Show("Review Added!" , "Success", MessageBoxButton.OK);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception: " + ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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
