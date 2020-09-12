using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelMap.Models;
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

                    var loginUser = new Account
                    {
                        Email = emailField,
                        Password = passwordField
                    };
                    var loggedIn = App.AccountRepo.Login(loginUser);

                    if (loggedIn >= 1)
                    {
                        // Get User Full Name
                        var fullName = App.AccountRepo.Get(loginUser.Email);

                        // Success: Logged In
                        await DisplayAlert("Login Successful", $"Welcome, {fullName.Name}", "Ok");

                        // Reset Login Fields
                        EmailLogin.Text = string.Empty;
                        PasswordLogin.Text = string.Empty;

                        await this.Navigation.PushAsync(new IntroPage());
                    }
                    else if (loggedIn == 0)
                    {
                        // Password Exist
                        await DisplayAlert("Password Incorrect", "You entered an incorrect password", "Try again");
                    }
                    else
                    {
                        await DisplayAlert("Error", "Account with this email does not exist", "Sign Up");

                        // Go to Sign up form
                        SignUpChangeBtn_Tapped(sender, e);
                    }

                    loginVm.IsBusy = false;
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

                    var newAccount = App.AccountRepo.Add(new Account
                    {
                        Name = nameField,
                        Email = emailField,
                        Password = passwordField
                    });

                    if (newAccount >= 1)
                    {
                        await DisplayAlert("Success", "Account created successfully", "Login");

                        // Success: Now Login User / Show Login Form
                        LoginChangeBtn_Tapped(sender, e);

                        // Reset Sign Up fields
                        NameSignup.Text = string.Empty;
                        EmailSignup.Text = string.Empty;
                        PasswordSignup.Text = string.Empty;
                    }
                    else if (newAccount == -1)
                    {
                        await DisplayAlert("Account exist", "Account with this email already exist", "Change Email");
                    }
                    else
                    {
                        await DisplayAlert("Error", "Couldn't create new account", "Try Again");
                    }

                    loginVm.IsBusy = false;
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