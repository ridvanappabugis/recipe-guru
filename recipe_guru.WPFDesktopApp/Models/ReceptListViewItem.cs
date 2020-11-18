using System;
using System.Windows.Media;

namespace recipe_guru.WPFDesktopApp.Models
{
    public class ReceptListViewItem
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public ImageSource Image { get; set; }
    }
}
