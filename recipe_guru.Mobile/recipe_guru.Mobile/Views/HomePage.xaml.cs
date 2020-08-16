using recipe_guru.Model.Requests;
using recipe_guru.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recipe_guru.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public HomeViewModel model = null;
        private readonly APIService _RatingService = new APIService("Rating");

        public Home()
        {
            InitializeComponent();
            BindingContext = model = new HomeViewModel();
        }
    }
}