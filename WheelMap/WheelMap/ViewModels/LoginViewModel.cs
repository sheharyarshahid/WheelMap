using System;
using System.Collections.Generic;
using System.Text;

namespace WheelMap.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private static LoginViewModel _instance;
        public static LoginViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoginViewModel();
                }

                return _instance;
            }
        }
    }
}
