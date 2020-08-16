using recipe_guru.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace recipe_guru.Mobile.ViewModels
{
    public class HomeViewModel
    {
        private readonly APIService _MTVSService = new APIService("MovieAndTvShow");
        private readonly APIService _NewsService = new APIService("News");
        private readonly APIService _QOTDService = new APIService("QuoteOfTheDay");

        public HomeViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public string LoggedUser { get
            {
                return APIService.Username;
            }
        }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
          
        }
    }
}
