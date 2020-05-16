using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelMap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroPage : ContentPage
    {
        public IntroViewModel IntroVM { get; set; }

        public IntroPage()
        {
            InitializeComponent();

            ContinueBtn.Clicked += ContinueBtn_Clicked;
        }

        private void ContinueBtn_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new MainPage());
        }
    }
}