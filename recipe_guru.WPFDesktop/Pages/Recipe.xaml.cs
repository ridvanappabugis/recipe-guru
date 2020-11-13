using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace recipe_guru.WPFDesktop.Pages
{
    /// <summary>
    /// Interaction logic for Recipe.xaml
    /// </summary>
    public partial class Recipe : Page
    {
        private int KnjigaId;
        private int RecipeId;

        public Recipe(int KnjigaId, int RecipeId)
        {
            InitializeComponent();

            this.KnjigaId = KnjigaId;
            this.RecipeId = RecipeId;
        }
    }
}
