using recipe_guru.Model;
using recipe_guru.WPFDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for RecipeBooks.xaml
    /// </summary>
    public partial class RecipeBooks : Page
    {
        public RecipeBooks()
        {
            InitializeComponent();

        }

        private readonly APIService _KnjigeRecepataService = new APIService("KnjigaRecepata");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");

        protected async void loaded_handler(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private async void Refresh()
        {
            ListViewKnjigeRecepata.Items.Clear();

            var lista = await _KnjigeRecepataService.Get<List<KnjigaRecepata>>(new Model.Requests.KnjigaRecepataSearchRequest
            {
                KorisnikId = APIService.UserId
            });

            foreach (var knjiga in lista)
            {
                Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(knjiga.ImageResourceId);

                ListViewKnjigeRecepata.Items.Add(new KnjigaRecepataListViewItem
                {
                    Id = knjiga.Id,
                    Naziv = knjiga.Naziv,
                    Deskripcija = knjiga.Deskripcija,
                    Image = imageResource != null ? new ImageService().arrayToImageSource(imageResource.ImageByteValue) : new ImageService().uriToImageSource("/Images/logo.png")
                });
            }
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new AddRecipeBook());
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new RecipeBook((button.DataContext as KnjigaRecepataListViewItem).Id));
        }
    }
}
