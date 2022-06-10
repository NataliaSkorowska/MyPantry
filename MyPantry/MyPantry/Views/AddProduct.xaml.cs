using MyPantry.Models;
using MyPantry.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
        // Zdjęcie
        private async void BtnCam_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Directory = "Xamarin",
                    SaveToAlbum = true
                });

                if (photo != null)
                    imgCam.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }
        async void Pick_Clicked(System.Object sender, System.EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Wybierz zdjęcie"
            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                imgCam.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}