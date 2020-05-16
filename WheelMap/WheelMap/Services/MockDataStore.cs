using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WheelMap.Models;

namespace WheelMap.Services
{
    public class MockDataStore : IDataStore<Place>
    {
        readonly List<Place> places;

        public MockDataStore()
        {
            places = new List<Place>
            {
                new Place
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Centaurus Mall",
                    Location = "Islamabad",
                    IsWheelChair = true,
                    Thumbnail = "https://www.croozi.com/upload/loc1024/1493144263location945.jpg"
                },

                new Place
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Dolmen Mall",
                    Location = "Karachi",
                    IsWheelChair = false,
                    Thumbnail = "https://media-cdn.tripadvisor.com/media/photo-o/13/09/39/8a/dolmen-mall.jpg"
                },
                new Place
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Port Grand",
                    Location = "Sea View Karachi",
                    IsWheelChair = true,
                    Thumbnail = "https://media-cdn.tripadvisor.com/media/photo-m/1280/15/32/e5/a3/a-grand-view-of-our-port.jpg"
                }
            };
        }

        public async Task<bool> AddItemAsync(Place item)
        {
            places.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Place item)
        {
            var oldItem = places.Where((Place arg) => arg.Id == item.Id).FirstOrDefault();
            places.Remove(oldItem);
            places.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = places.Where((Place arg) => arg.Id == id).FirstOrDefault();
            places.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Place> GetItemAsync(string id)
        {
            return await Task.FromResult(places.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Place>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(places);
        }
    }
}