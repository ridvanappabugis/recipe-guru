using System;
using Xamarin.Forms;

namespace recipe_guru.Mobile.Models
{
    public class KnjigaRecepataListViewItem
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Deskripcija { get; set; }
        public ImageSource Image { get; set; }
    }
}
