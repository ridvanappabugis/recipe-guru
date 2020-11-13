using recipe_guru.WPFDesktop.Models;
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

namespace recipe_guru.WPFDesktop.Pages
{
    /// <summary>
    /// Interaction logic for RecipeBook.xaml
    /// </summary>
    public partial class RecipeBook : Page
    {
        private int KnjigaId;

        public RecipeBook(int KnjigaId)
        {
            InitializeComponent();

            this.KnjigaId = KnjigaId;
        }

        private readonly APIService _ReceptService = new APIService("Recept");
        private readonly APIService _ImageResourceService = new APIService("ImageResource");

        protected  async void loaded_handler(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private async void Refresh()
        {
            try
            {
                ListViewRecepti.ItemsSource = null; ;

                var lista = await _ReceptService.Get<List<Model.Recept>>(new Model.Requests.ReceptSearchRequest
                {
                    KnjigaRecepataId = KnjigaId
                });

                foreach (var recept in lista)
                {
                    Model.ImageResource imageResource = await _ImageResourceService.GetById<Model.ImageResource>(recept.ImageResourceId);

                    ListViewRecepti.Items.Add(new ReceptListViewItem
                    {
                        Id = recept.Id,
                        Naziv = recept.Naziv,
                        Image = imageResource != null ? new ImageService().arrayToImageSource(imageResource.ImageByteValue) : new ImageService().uriToImageSource("/Images/logo.png")
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception: " + ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new AddRecipeBook());
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RecipeBooks());
        }

    }
}
