using MyPantry.Models;
using MyPantry.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MyPantry.ViewModels
{
    public class VMProducts : INotifyPropertyChanged
    {
        private ObservableCollection<Products> _lstProducts { get; set; }

        public ObservableCollection<Products> lstProducts
        {
            get { return _lstProducts; }
            set
            {
                _lstProducts = value;
                OnPropertyChanged();
            }
        }

        public Command btnAddProduct { get; set; }

        private string _lblInfo { get; set; }
        public string lblInfo
        {
            get { return _lblInfo; }
            set
            {
                _lblInfo = value;
                OnPropertyChanged();
            }
        }

        public VMProducts()
        {
            lstProducts = new ObservableCollection<Products>();

        }

        public void GetProducts()
        {
            try
            {
                ProductDatabase productDatabase = new ProductDatabase();
                var products = productDatabase.getProducts().Result;

                if (products != null && products.Count > 0)
                {
                    lstProducts = new ObservableCollection<Products>();

                    foreach (var prod in products)
                    {
                        lstProducts.Add(new Products
                        {
                            ID = prod.ID,
                            Name = prod.Name,
                            Price = prod.Price,
                            Description = prod.Description
                        });
                    }

                    lblInfo = "Ilość produktów w spiżarni: " + products.Count.ToString();
                }
                else
                    lblInfo = "Brak produktów w spiżarni - czas zrobić zakupy";
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }

        public void DeleteProduct(Products product)
        {
            try
            {
                ProductDatabase productDatabase = new ProductDatabase();
                var result = productDatabase.deleteProduct(product).Result;

                if (result == 1)
                    GetProducts();
                else
                    lblInfo = "Nie można usunąć produktu";
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
