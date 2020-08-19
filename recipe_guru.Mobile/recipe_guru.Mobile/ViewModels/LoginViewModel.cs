using recipe_guru.Model;
using recipe_guru.Model.Requests;
using recipe_guru.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace recipe_guru.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _testService = new APIService("Kategorije");
        private readonly APIService _serviceUser = new APIService("Korisnici");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            try
            {
                await _testService.Get<dynamic>(null);
                List<Model.Korisnik> temp = await _serviceUser.Get<List<Model.Korisnik>>(new KorisniciSearchRequest
                {
                   UserName = Username
                });
                APIService.User = temp.FirstOrDefault();
                APIService.UserId = temp.Select(x => x.Id).FirstOrDefault();
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
