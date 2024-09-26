using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace Module02Exercise01
{
    public partial class App : Application
    {
        private const string TestUrl = "https://reqbin.com";
        private readonly IServiceProvider _serviceProvider;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            MainPage = new AppShell(); // Ensure AppShell is set as the MainPage
            Shell.Current.GoToAsync("//LoginPage"); // Ensure the app starts at the LoginPage
        }

        // The connectivity check now happens after login
        public async Task CheckConnectionAndNavigate()
        {
            var current = Connectivity.NetworkAccess;
            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (Shell.Current == null)
            {
                Debug.WriteLine("Shell.Current is null. Cannot navigate.");
                return;
            }

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                await Shell.Current.GoToAsync("//EmployeePage");
                Debug.WriteLine("Application Online - Navigating to StartPage");
            }
            else
            {
                await Shell.Current.GoToAsync("//OfflinePage");
                Debug.WriteLine("Application Offline - Navigating to OfflinePage");
            }
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("Application Sleeping");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("Application Resumed");
        }

        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0");
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
