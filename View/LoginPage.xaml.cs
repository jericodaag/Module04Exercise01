using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace Module02Exercise01.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Retrieve the username and password from the Entry fields
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Replace the following line with your actual login logic
            bool loginSuccessful = await PerformLogin(username, password);

            if (loginSuccessful)
            {
                // Call CheckConnectionAndNavigate after successful login
                var app = (App)Application.Current;
                await app.CheckConnectionAndNavigate();
            }
            else
            {
                // Handle login failure
                await DisplayAlert("Login Failed", "Invalid username or password.", "OK");
            }
        }

        // Mock login method (replace this with your actual login logic)
        private Task<bool> PerformLogin(string username, string password)
        {
            // Example logic for successful login
            return Task.FromResult(username == "1" && password == "1");
        }
    }
}
