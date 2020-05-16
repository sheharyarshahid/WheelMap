using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WheelMap.Droid.Services;
using WheelMap.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilePathService))]
namespace WheelMap.Droid.Services
{
    public class FilePathService : IFilePathService
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, fileName);
        }
    }
}