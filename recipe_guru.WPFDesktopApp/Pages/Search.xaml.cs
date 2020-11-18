using recipe_guru.WPFDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();
        }

        private readonly APIService _ReceptService = new APIService("Recept");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");
        private readonly APIService _KategorijeService = new APIService("Kategorije");

        public ObservableCollection<ReceptListViewItem> Recepti { get; set; } = new ObservableCollection<ReceptListViewItem>();
        public ObservableCollection<Model.Kategorija> Kategorije { get; set; } = new ObservableCollection<Model.Kategorija>();

        public List<string> ratings { get; set; } = new List<string> { "\u2605", "\u2605 \u2605", "\u2605 \u2605 \u2605", "\u2605 \u2605 \u2605 \u2605", "\u2605 \u2605 \u2605 \u2605 \u2605" };
        public List<int> duzinePripreme { get; set; } = new List<int> { 10, 20, 30, 50, 80, 150, 200 };


        protected async void loaded_handler(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void filterEvent(object sender, RoutedEventArgs e)
        {
            FilterItems();
        }

        internal async void FilterItems()
        {
            Recepti.Clear();

            Model.Requests.ReceptSearchRequest request = new Model.Requests.ReceptSearchRequest();

            if (selectedRatingFilter.SelectedIndex != -1)
            {
                request.AverageRating = createStars(selectedRatingFilter.Text);
            }
            if (selectedEffortFilter.SelectedIndex != -1)
            {
                request.DuzinaPripreme = Int32.Parse(selectedEffortFilter.Text);
            }
            if (KategorijePicker.SelectedIndex != -1)
            {
                request.KategorijaId = ((Model.Kategorija)KategorijePicker.SelectedItem).Id;
            }
            if (txtSearch.Text != null && txtSearch.Text != "")
            {
                request.Naziv = txtSearch.Text;
            }

            var lista = await _ReceptService.Get<List<Model.Recept>>(request);

            foreach (var recept in lista)
            {
                Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(recept.ImageResourceId);

                Recepti.Add(new ReceptListViewItem
                {
                    Id = recept.Id,
                    Naziv = recept.Naziv,
                    Image = imageResource != null ? new ImageService().arrayToImageSource(imageResource.ImageByteValue) : new ImageService().uriToImageSource("/Images/logo.png")
                });
            }
        }

        internal async void Init()
        {
            try
            {
                var kategorijeList = await _KategorijeService.Get<List<Model.Kategorija>>(null);

                foreach (var kat in kategorijeList)
                {
                    Kategorije.Add(kat);
                }

                ListViewRecepti.ItemsSource = Recepti;

                KategorijePicker.ItemsSource = Kategorije;
                selectedRatingFilter.ItemsSource = ratings;
                selectedEffortFilter.ItemsSource = duzinePripreme;
                KategorijePicker.SelectedItem = null;
                selectedRatingFilter.SelectedItem = null;
                selectedEffortFilter.SelectedItem = null;

                FilterItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception: " + ex.Message, "Error", MessageBoxButton.OK);
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

        private void btnViewRecipe_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            NavigationService ns = NavigationService.GetNavigationService(this);
           ns.Navigate(new Recipe((button.DataContext as ReceptListViewItem).Naziv, (button.DataContext as ReceptListViewItem).Id, false));
        }
    }
}
