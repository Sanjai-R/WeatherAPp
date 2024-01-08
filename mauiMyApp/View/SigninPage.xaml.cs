using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using mauiMyApp.Interface;
using mauiMyApp.Helpers;

namespace mauiMyApp.View
{
    public partial class SigninPage : ContentPage
    {
        private readonly ISqliteDb _localDb;
        public SigninPage()
        {
            InitializeComponent();
            _localDb = ServiceHelper.Current.GetRequiredService<ISqliteDb>();
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
            var isUserLoggedIn = await _localDb.LoginUser(EmailEntry.Text, PasswordEntry.Text);
            if (isUserLoggedIn)
            {
                await Shell.Current.GoToAsync("detailPage");
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

