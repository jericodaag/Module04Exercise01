using Microsoft.Maui.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Module02Exercise01.View
{
    public partial class AddEmployee : ContentPage
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private async void OnTakePhotoClicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    EmployeeImage.Source = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to capture photo: {ex.Message}", "OK");
            }
        }

        private async void OnGetLocationClicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                if (location != null)
                {
                    CoordinatesLabel.Text = $"Coordinates: {location.Latitude:F6}, {location.Longitude:F6}";

                    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                    var placemark = placemarks?.FirstOrDefault();
                    if (placemark != null)
                    {
                        MunicipalityEntry.Text = placemark.Locality ?? placemark.SubAdminArea;
                        ProvinceEntry.Text = placemark.AdminArea;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Unable to get location: {ex.Message}", "OK");
            }
        }

        private async void OnAddEmployeeClicked(object sender, EventArgs e)
        {
            // Implement the logic to save the employee data
            // For now, we'll just show a success message
            await DisplayAlert("Success", "Employee added successfully!", "OK");
            await Navigation.PopAsync(); // Go back to the previous page
        }
    }
}