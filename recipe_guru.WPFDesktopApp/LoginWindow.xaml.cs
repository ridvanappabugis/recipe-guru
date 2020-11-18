using recipe_guru.Model.Requests;
using recipe_guru.WPFDesktopApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace recipe_guru.WPFDesktopApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();
            _mainFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            _mainFrame.Navigate(new Login());
        }
    }
}