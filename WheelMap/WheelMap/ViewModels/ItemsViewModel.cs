using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using WheelMap.Models;
using WheelMap.Views;

namespace WheelMap.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private static ItemsViewModel _instance;
        public static ItemsViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ItemsViewModel();
                }

                return _instance;
            }
        }

        public ObservableCollection<Place> Places { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Places";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            Places = new ObservableCollection<Place>();

            MessagingCenter.Subscribe<NewItemPage, Place>(this, "AddItem", async (obj, place) =>
            {
                var newPlace = place as Place;
                Places.Insert(0, newPlace);
                await DataStore.AddItemAsync(newPlace);

                MessagingCenter.Send(this, "ScrollUp");
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Places.Clear();
                var places = await DataStore.GetItemsAsync(true);
                foreach (var place in places)
                {
                    Places.Add(place);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}