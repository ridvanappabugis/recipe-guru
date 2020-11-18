using System;
using System.Windows.Media;

namespace recipe_guru.WPFDesktopApp.Models
{
    public class KnjigaRecepataListViewItem
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Deskripcija { get; set; }
        public ImageSource Image { get; set; }
    }
}
