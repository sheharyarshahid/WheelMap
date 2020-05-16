using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WheelMap.Services;
using WheelMap.Views;

namespace WheelMap
{
    public partial class App : Application
    {
        private static AccountRepository _accountRepo;
        public static AccountRepository AccountRepo
        {
            get
            {
                if (_accountRepo == null)
                {
                    // Database Name
                    const string dbName = "WheelMap.db3";
                    // Local Database Full Path
                    string dbPath = DependencyService.Get<IFilePathService>().GetLocalFilePath(dbName);
                    // Initialize a new Account Repository
                    _accountRepo = new AccountRepository(dbPath);
                }

                return _accountRepo;
            }
        }


        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
