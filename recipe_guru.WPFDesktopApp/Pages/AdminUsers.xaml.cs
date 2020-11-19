using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Microsoft.Reporting.WinForms;
using recipe_guru.Model.ReportModels;

namespace recipe_guru.WPFDesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for AdminUsers.xaml
    /// </summary>
    public partial class AdminUsers : Page
    {
        private List<frmUserSearchVM> _source;
        public AdminUsers(List<frmUserSearchVM> _source)
        {
            InitializeComponent();
            this._source = _source;
            
        }

        private void frmRptUser_Load(object sender, EventArgs e)
        {

        }
    }
}
