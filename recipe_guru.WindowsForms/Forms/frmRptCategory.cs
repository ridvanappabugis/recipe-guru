using recipe_guru.Model.ReportModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recipe_guru.WindowsFormsUI.Forms
{
    public partial class frmRptCategory : Form
    {
        private List<frmCategoriesVM> _source;
        public frmRptCategory(List<frmCategoriesVM> _source)
        {
            InitializeComponent();
            this._source = _source;
        }

        private void frmRptUser_Load(object sender, EventArgs e)
        {
            frmCategoryVMBindingSource.DataSource = _source;
            this.reportViewer1.RefreshReport();
        }
    }
}
