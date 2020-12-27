using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using recipe_guru.Mobile.Converters;
using recipe_guru.Mobile.Models;
using Xamarin.Forms;

namespace recipe_guru.Mobile.ViewModels
{
    public class ReceptPretragaViewModel : BaseViewModel
    {
        private readonly APIService _ReceptService = new APIService("Recept");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");
        private readonly APIService _KategorijeService = new APIService("Kategorije");
        private bool isInit = true;

        public ObservableCollection<ReceptListViewItem> Recepti { get; set; } = new ObservableCollection<ReceptListViewItem>();

        public ObservableCollection<Model.Kategorija> Kategorije { get; set; } = new ObservableCollection<Model.Kategorija>();

        public List<string> ratings { get; set; } = new List<string> { "\u2605", "\u2605 \u2605", "\u2605 \u2605 \u2605", "\u2605 \u2605 \u2605 \u2605", "\u2605 \u2605 \u2605 \u2605 \u2605" };
        public List<int> duzinePripreme { get; set; } = new List<int> { 10, 20, 30, 50, 80, 150, 200 };

        Model.Kategorija selectedCategoryFilter = null;
        public Model.Kategorija SelectedCategoryFilter
        {
            get => selectedCategoryFilter;
            set
            {
                selectedCategoryFilter = value;
                if (!isInit) 
                FilterItems();
            }
        }

        int selectedEffortFilter = 0;
        public int SelectedEffortFilter
        {
            get => selectedEffortFilter;
            set
            {
                selectedEffortFilter = value;
                if (!isInit)
                    FilterItems();
            }
        }

        string selectedRatingFilter = string.Empty;
        public string SelectedRatingFilter
        {
            get => selectedRatingFilter;
            set
            {
                selectedRatingFilter = value;
                if (!isInit)
                    FilterItems();
            }
        }

        public ReceptPretragaViewModel()
        {
        }

        internal async Task FilterItems()
        {
            Recepti.Clear();

            Model.Requests.ReceptSearchRequest request = new Model.Requests.ReceptSearchRequest();

            if (selectedRatingFilter != string.Empty && selectedRatingFilter != null)
            {
                request.AverageRating = createStars(selectedRatingFilter);
            }

            if (selectedEffortFilter != 0)
            {
                request.DuzinaPripreme = selectedEffortFilter;
            }

            if (selectedCategoryFilter != null)
            {
                request.KategorijaId = selectedCategoryFilter.Id;
            }

            var lista = await _ReceptService.Get<List<Model.Recept>>(request);

            foreach (var recept in lista)
            {
                Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(recept.ImageResourceId);

                Recepti.Add(new ReceptListViewItem
                {
                    Id = recept.Id,
                    Naziv = recept.Naziv,
                    Image = imageResource != null ? new ImageConverter().Convert(imageResource.ImageByteValue) : "notfound.png"
                });
            }
        }

        internal async Task Init()
        {
            try
            {
                var kategorijeList = await _KategorijeService.Get<List<Model.Kategorija>>(null);

                foreach (var kat in kategorijeList)
                {
                    Kategorije.Add(kat);
                }

                Recepti.Clear();
                isInit = false;

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
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
