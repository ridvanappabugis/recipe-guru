using System;
using System.Collections.Generic;
using System.Text;

namespace recipe_guru.Mobile.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Logout,
        Home,
        YourProfile
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
