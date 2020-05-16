using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WheelMap.Models;
using System.Threading.Tasks;
using WheelMap.ViewModels;

namespace WheelMap.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public ItemsViewModel ItemsVM { get; set; }
        public Place NewPlace { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            NewPlace = new Place();

            BindingContext = this;
            LoadingPanel.BindingContext = ItemsVM = ItemsViewModel.Instance;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Button addBtn = sender as Button;
            addBtn.IsEnabled = false;

            ItemsVM.IsBusy = true;

            MessagingCenter.Send(this, "AddItem", NewPlace);

            await Task.Delay(2000);

            ItemsVM.IsBusy = false;
            addBtn.IsEnabled = true;
            var newPlace = NewPlace.Name ?? "New Place";
            //NewPlace = null;
            await DisplayAlert("Success", $"{newPlace} was added successfully", "Ok");

            MessagingCenter.Send(this, "ChangeTab");
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}