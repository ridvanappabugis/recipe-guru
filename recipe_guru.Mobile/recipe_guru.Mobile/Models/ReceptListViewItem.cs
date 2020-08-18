using System;
using Xamarin.Forms;

namespace recipe_guru.Mobile.Models
{
    public class ReceptListViewItem
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public ImageSource Image { get; set; }
    }
}
