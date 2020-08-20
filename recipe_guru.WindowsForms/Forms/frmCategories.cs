using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using recipe_guru.Model.ReportModels;


namespace recipe_guru.WindowsFormsUI.Forms
{
    public partial class frmCategories : Form
    {
        APIService _serviceKategorije = new APIService("Kategorije");
        APIService _serviceUserType = new APIService("Recept");

        public frmCategories()
        {
            InitializeComponent();
        }

        private async Task LoadCategories()
        {
            var list = await _serviceKategorije.GetAll<List<Model.Kategorija>>(null);
            List<frmCategoriesVM> vm = new List<frmCategoriesVM>();
            foreach (var item in list)
            {
                frmCategoriesVM categoryStatistics = new frmCategoriesVM
                {
                    Id = item.Id,
                    Naziv = item.Naziv,
                    AvgRating = 0,
                    BrojPregleda = 0,
                    BrojRecepata = 0
                };
                vm.Add(categoryStatistics);
            }
            dgvCategory.DataSource = vm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRptCategory frm = new frmRptCategory(dgvCategory.DataSource as List<frmCategoriesVM>);
            frm.Show();
        }

        private async void frmCategories_Load(object sender, EventArgs e)
        {
            dgvCategory.AutoGenerateColumns = false;
            await LoadCategories();
        }
    }
}
