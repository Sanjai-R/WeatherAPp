using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace DemoApp.View
{	
	public partial class RegisterPage : ContentPage
	{	
		public RegisterPage()
		{
			InitializeComponent ();
		}
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text) || string.IsNullOrWhiteSpace(EmailEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Authentication Error", "All fields are required", "Cancel");
            }
            else
            {
                await RegisterAndNavigate();
            }
        }
        private async Task RegisterAndNavigate()
        {
            try
            {
                int result = await RegisterUser();

                if (result > 0)
                {
                    await Navigation.PushModalAsync(new SigninPage());
                }
                else
                {
                    await DisplayAlert("Registration Error", "Failed to register user", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
                await DisplayAlert("Error", "An error occurred while registering user", "OK");
            }
        }

        private async Task<int> RegisterUser()
        {
            return await App.MyDb.CreateUser(
                new Model.UserModel
                {
                    email = EmailEntry.Text,
                    username = UsernameEntry.Text,
                    password = PasswordEntry.Text
                }
            );
        }

        
    }
}

