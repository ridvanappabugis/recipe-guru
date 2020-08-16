using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace recipe_guru.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            imgDisp.Source = "logo_transparent.png";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterUserPage());
        }
    }
}