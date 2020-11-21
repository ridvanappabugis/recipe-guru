using System;
using System.Collections.Generic;
using System.Text;

namespace recipe_guru.Model.ReportModels
{
    public class frmRecipesUsersVM
    {
        public int Id { get; set; }

        public string RecipeBook { get; set; }

        public string Naziv { get; set; }
        public string Description { get; set; }

        public string Kategorija { get; set; }

        public int NumberOfViews { get; set; }

        public int NumberOfRatings { get; set; }

        public int AverageRating { get; set; }

    }
}
