using System;
using System.Collections.Generic;
using recipe_guru.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recipe_guru.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingListPage : ContentPage
    {
        public RatingsViewModel model = null;

        public RatingListPage(int ReceptId, string naziv)
        {
            InitializeComponent();
            BindingContext = model = new RatingsViewModel(ReceptId, naziv);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}
