using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace WheelMap.ViewModels
{
    public class IntroViewModel : BaseViewModel
    {
        public ObservableCollection<Intro> IntroPages { get; set; }

        private static IntroViewModel _instance;
        public static IntroViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IntroViewModel();
                }

                return _instance;
            }
        }

        private Intro _selectedIntroPage;
        public Intro SelectedIntroPage
        {
            get => _selectedIntroPage;
            set => SetProperty(ref _selectedIntroPage, value);
        }

        public IntroViewModel()
        {
            IntroPages = new ObservableCollection<Intro>()
            {
                new Intro
                {
                    Id = 1,
                    BGColor = Color.FromHex("#24BE92"),
                    Icon = "",
                    Title = "Introduction",
                    Description = "Accessible Points for people on Wheelchair will be a mobile application designed for people who are on wheel chair and practically handicapped"                    
                },
                new Intro
                {
                    Id = 2,
                    BGColor = Color.FromHex("#BE2476"),
                    Icon = "",
                    Title = "Problem Statement",
                    Description = "Straightforward things like shopping and visiting food points become an extremely troublesome and complex task in all situations rapidly for people on wheelchair."
                },
                new Intro
                {
                    Id = 3,
                    BGColor = Color.FromHex("#247CBE"),
                    Icon = "",
                    Title = "Proposed solution",
                    Description = "User will be given facility to search for a location where he/she wants to go and search the accessibility of ramps and elevators in that places, they are also given a facility to share their location with their family."
                },
            };
        }
    }

    public class Intro
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Color BGColor { get; set; }
        public string Icon { get; set; }
    }
}
