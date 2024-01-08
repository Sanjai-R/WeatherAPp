using mauiMyApp.Helpers;
using mauiMyApp.Interface;
namespace mauiMyApp.View
{

    public partial class RegisterPage : ContentPage
    {
        private readonly ISqliteDb _localDb;
        public RegisterPage()
        {
            _localDb = ServiceHelper.Current.GetRequiredService<ISqliteDb>();
            InitializeComponent();
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
                Console.WriteLine(result);
                if (result > 0)
                {
                    await Shell.Current.GoToAsync("login");
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

            return await _localDb.CreateUser(
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