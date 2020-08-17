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
