using MyPantry.ViewModels;
using MyPantry.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyPantry
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(ProductPage), typeof(ProductPage));
        }

    }
}
