using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using recipe_guru.Model.Requests;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for AdminAddCategory.xaml
    /// </summary>
    public partial class AdminAddCategory : Page
    {
        public AdminAddCategory()
        {
            InitializeComponent();
        }

        APIService _serviceKategorije = new APIService("Kategorije");

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCategoryName.Text == null || txtCategoryName.Text == "")
                {
                    MessageBox.Show("Category Name is required! Try again.", "Error", MessageBoxButton.OK);
                    return;
                }


                await _serviceKategorije.Insert<Model.Kategorija>(new KategorijeAddRequest()
                {
                    Naziv = txtCategoryName.Text
                });

                MessageBox.Show("Added Successfully!", "Info", MessageBoxButton.OK);

                NavigationService ns = NavigationService.GetNavigationService(this);
                ns.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled exception: " + ex.Message, "Error", MessageBoxButton.OK);
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.GoBack();
        }

    }
}
