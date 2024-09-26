using Microsoft.Maui.Controls;

namespace Module02Exercise01.View
{
    public partial class EmployeePage : ContentPage
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        private async void OnAddEmployeeClicked(object sender, EventArgs e)
        {
            // Ensure the route is correct for AddEmployee page
            await Shell.Current.GoToAsync("//AddEmployee");
        }
    }
}
