using MyPantry.Models;
using MyPantry.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPantry.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {
        
        public AddProduct(Products product)
        {
            try
            {
                InitializeComponent();
                VMAddProduct vm = new VMAddProduct(product);
                this.BindingContext = vm;
                

            }
            catch (Exception ex)
            {

            }

        }
    
    }
}