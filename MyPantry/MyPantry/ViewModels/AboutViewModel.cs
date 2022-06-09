using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyPantry.ViewModels
{
    public class AboutViewModel : ContentPage
    {
     
        public AboutViewModel()
        {
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}