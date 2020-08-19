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
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            frmHome childForm = new frmHome();
            childForm.MdiParent = this;
            childForm.Text = "Home";
            childForm.Show();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHome frm = new frmHome();
            frm.MdiParent = this;
            frm.Show();
        }

        
        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmUserAdd frm = new frmUserAdd();
            frm.MdiParent = this;
            frm.Show();
        }

        private void searchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmUserSearch frm = new frmUserSearch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void personToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategories frm = new frmCategories();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
