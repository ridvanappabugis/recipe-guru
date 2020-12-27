using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Reporting.WebForms;
using recipe_guru.Model.ReportModels;
using MessageBox = System.Windows.MessageBox;

namespace recipe_guru.WPFDesktopApp
{
    class ReportingService
    {

        internal void CreateCategoriesPDF(List<frmCategoriesVM> lists)
        {
            // Setup the report viewer object and get the array of bytes  
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "Reports/rptCategories.rdlc";
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", lists));

            SaveReport(viewer);
        }

        internal void CreateUsersPDF(List<frmUserSearchVM> lists)
        {
            // Setup the report viewer object and get the array of bytes  
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "Reports/rptUsers.rdlc";
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", lists));

            SaveReport(viewer);
        }

        internal void CreateRecipesPDF(List<frmRecipesUsersVM> lists)
        {
            // Setup the report viewer object and get the array of bytes  
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "Reports/rptRecipes.rdlc";
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", lists));

            SaveReport(viewer);
        }

        private void SaveReport(ReportViewer viewer)
        {
            // Variables  
   
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            byte[] bytes = viewer.LocalReport.Render("PDF");

            using (var dialog = new System.Windows.Forms.SaveFileDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(dialog.FileName + ".pdf", FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    MessageBox.Show("Report created.", "Info", MessageBoxButton.OK);

                }

            }
        }
    }
}
