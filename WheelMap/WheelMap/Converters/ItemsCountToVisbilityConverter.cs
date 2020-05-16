using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WheelMap.ViewModels;
using Xamarin.Forms;

namespace WheelMap.Converters
{
    public class ItemsCountToVisbilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            // Selected Page Id
            var pageId = (value as Intro).Id;
            if (pageId == 3)
            {
                return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
