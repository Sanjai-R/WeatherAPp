using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoApp.View
{
    public partial class SigninPage : ContentPage
    {
        public SigninPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordEntry.Text) || string.IsNullOrWhiteSpace(EmailEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Authentication Error", "All fields are required", "Cancel");
            }
            else
            {
                await LoginUser();


            }
        }

        private async Task<Boolean> LoginUser()
        {
            var isUserLoggedIn = await App.MyDb.LoginUser(EmailEntry.Text, PasswordEntry.Text);
            if (isUserLoggedIn)
            {
                Application.Current.MainPage = new DetailPage();
            }
            else
            {
                Console.WriteLine("Login Error");
                await DisplayAlert("Authentication Error", "Invalid username or password", "Cancel");
            }
            return true;
        }
    }
}

