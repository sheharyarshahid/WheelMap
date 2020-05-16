using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelMap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginVm;

        public LoginPage()
        {
            InitializeComponent();

            BindingContext = loginVm = LoginViewModel.Instance;

            LoginBtn.Clicked += LoginBtn_Clicked;
            SignupBtn.Clicked += SignupBtn_Clicked;
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            var emailField = EmailLogin.Text;
            var passwordField = PasswordLogin.Text;

            if (!string.IsNullOrWhiteSpace(emailField) && !string.IsNullOrWhiteSpace(passwordField))
            {
                // Success : Login user
                if (emailField.Length >= 6 && passwordField.Length >= 6)
                {
                    loginVm.IsBusy = true;

                    await Task.Delay(3000);

                    await DisplayAlert("Success", "Login successful", "Ok");

                    loginVm.IsBusy = false;

                    await this.Navigation.PushAsync(new IntroPage());
                }
                else
                {
                    await DisplayAlert("Error", "All fields must be greater than 6 characters", "Ok");
                }
            }
            else
            {
                // Error
                await DisplayAlert("Error", "All fields are required", "Ok");
            }
        }

        private async void SignupBtn_Clicked(object sender, EventArgs e)
        {
            var nameField = NameSignup.Text;
            var emailField = EmailSignup.Text;
            var passwordField = PasswordSignup.Text;

            if (!string.IsNullOrEmpty(nameField) && !string.IsNullOrEmpty(emailField) && !string.IsNullOrEmpty(passwordField))
            {
                if (nameField.Length >= 6 && emailField.Length >= 6 && passwordField.Length >= 6)
                {
                    loginVm.IsBusy = true;

                    await Task.Delay(3000);

                    await DisplayAlert("Success", "Account created successfully", "Login");

                    loginVm.IsBusy = false;

                    // Success: Now Login User / Show Login Form
                    LoginChangeBtn_Tapped(sender, e);

                    //await this.Navigation.PushAsync(new IntroPage());
                }
                else
                {
                    // Error
                    await DisplayAlert("Error", "All fields must be greater than 6 characters", "Ok");
                }
            }
            else
            {
                // Error
                await DisplayAlert("Error", "All fields are required", "Ok");
            }
        }

        private void SignUpChangeBtn_Tapped(object sender, EventArgs e)
        {
            if (LoginPanel.IsVisible)
            {
                LoginPanel.IsVisible = false;
                SignUpPanel.IsVisible = true;
            }
        }

        private void LoginChangeBtn_Tapped(object sender, EventArgs e)
        {
            if (SignUpPanel.IsVisible)
            {
                SignUpPanel.IsVisible = false;
                LoginPanel.IsVisible = true;
            }
        }
    }
}