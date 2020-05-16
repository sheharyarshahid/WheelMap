using System;

using WheelMap.Models;

namespace WheelMap.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Place Place { get; set; }
        public ItemDetailViewModel(Place place = null)
        {
            Title = place?.Name;
            Place = place;
        }
    }
}
