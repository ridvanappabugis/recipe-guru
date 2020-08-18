using System;
using System.Collections.Generic;
using recipe_guru.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recipe_guru.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        public RecipeViewModel model = null;

        public RecipePage(int ReceptId)
        {
            InitializeComponent();
            BindingContext = model = new RecipeViewModel(ReceptId);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        public async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RatingListPage(model.receptId, model.NazivRecepta));
        }

        public async void OnAddRatingButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddRatingPage(model.receptId));
        }

        public async void OnSimilarRecipesClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SimilarRecipesPage(model.receptId, model.KategorijaId, model.NazivRecepta));
        }
    }
}
