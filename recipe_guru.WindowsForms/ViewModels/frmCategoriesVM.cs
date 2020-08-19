using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe_guru.WindowsFormsUI.ViewModels
{
    class frmCategoriesVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public int AvgRating { get; set; }

        public int BrojPregleda { get; set; }

        public int BrojRecepata { get; set; }
    }
}
