using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using recipe_guru.Mobile.Converters;
using recipe_guru.Mobile.Models;
using Xamarin.Forms;

namespace recipe_guru.Mobile.ViewModels
{
    public class SimilarRecipesViewModel : BaseViewModel
    {
        private readonly APIService _RecommendService = new APIService("Recommend");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");

        public ObservableCollection<ReceptListViewItem> Recepti { get; set; } = new ObservableCollection<ReceptListViewItem>();

        public int ReceptId { get; set; }
        public int KategorijaId { get; set; }
        public string NazivRecepta { get; set; }

        public SimilarRecipesViewModel(int RecipeId, int KategorijaId, string nazivRecepta)
        {
            this.ReceptId = RecipeId;
            this.KategorijaId = KategorijaId;
            this.NazivRecepta = "Similar to " + nazivRecepta;
        }

        internal async Task Init()
        {
            try
            {
                Recepti.Clear();

                var lista = await _RecommendService.Get<List<Model.Recept>>(new Model.Requests.RecommendSearchRequest
                {
                    ReceptId = ReceptId,
                    KategorijaId = KategorijaId
                });

                foreach (var recept in lista)
                {
                    Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(recept.ImageResouceId);

                    Recepti.Add(new ReceptListViewItem
                    {
                        Id = recept.Id,
                        Naziv = recept.Naziv,
                        Image = imageResource != null ? new ImageConverter().Convert(imageResource.ImageByteValue) : "notfound.png"
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }

        }
    }
}
