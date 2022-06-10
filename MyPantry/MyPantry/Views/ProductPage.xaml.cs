using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPantry.Models;
using MyPantry.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPantry.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        VMProducts vm;
        public ProductPage()
        {
            InitializeComponent();
            vm = new VMProducts();
            this.BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            if (vm != null)
                vm.GetProducts();

            base.OnAppearing();
        }

        private async void btnAddProduct_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProduct(null));
        }
        private async void lstProduct_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (lstProduct.SelectedItem != null)
                {
                    var product = (Products)lstProduct.SelectedItem;
                    lstProduct.SelectedItem = null;
                    await Navigation.PushAsync(new AddProduct(product));
                }
            }
            catch (Exception ex)
            {

            }
        }     
        private async void btnDeleteProduct_Clicked(object sender, EventArgs e)
        {
            try
            {
                string ID = (sender as Button).CommandParameter.ToString();
                if (!string.IsNullOrWhiteSpace(ID))
                {
                    var product = vm.lstProducts.Where(x => x.ID.ToString() == ID);
                    var result = await DisplayAlert("Zatwierdź", "Czy chcesz usunąć produkt: " + product.FirstOrDefault().Name + "?", "Usuń", "Anuluj");
                    if (result)
                        vm.DeleteProduct(product.FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
