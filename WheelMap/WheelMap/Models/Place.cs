using System;
using System.Collections.Generic;
using System.Text;

namespace WheelMap.Models
{
    public class Place
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Thumbnail { get; set; }
        public bool IsWheelChair { get; set; }
    }
}
