using MyPantry.Models;
using MyPantry.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MyPantry.ViewModels
{
    public class VMAddProduct : INotifyPropertyChanged
    {
        private Products _products { get; set; }
        public Products product
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

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

        private string _btnSaveLabel { get; set; }
        public string btnSaveLabel
        {
            get { return _btnSaveLabel; }
            set
            {
                _btnSaveLabel = value;
                OnPropertyChanged();
            }
        }

        public Command btnSaveProduct { get; set; }
        public Command btnClearProduct { get; set; }
        public VMAddProduct(Products obj)
        {
            if (obj == null || obj.ID == 0)
                ClearProduct();

            else
            {
                product = obj;
                btnSaveLabel = "EDYTUJ";
            }
            btnSaveProduct = new Command(SaveProduct);
            btnClearProduct = new Command(ClearProduct);
        }

        public void SaveProduct()
        {
            try
            {
                ProductDatabase productDatabase = new ProductDatabase();
                int i = productDatabase.saveProduct(product).Result;

                if (i == 1)
                {

                    if (btnSaveLabel.Equals("DODAJ"))
                    {
                        ClearProduct();
                        lblInfo = "Produkt został zapisany";
                    }
                    else
                    {
                        ClearProduct();
                        lblInfo = "Produkt został poprawnie zmieniony";
                    }
                }
                else
                    lblInfo = "Nie można zapisać informacji o produkcie";
            }

            catch (Exception ex)
            {
                lblInfo = ex.Message.ToString();
            }
        }
        public void ClearProduct()
        {
            product = new Products();
            product.ID = 0;
            product.Name = "";
            product.Price = 0;
            product.Description = "";
            product.Image = "";
            lblInfo = "";
            btnSaveLabel = "DODAJ";
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
