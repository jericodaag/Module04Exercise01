namespace Module02Exercise01.View;
using Module02Exercise01.Services;

public partial class StartPage : ContentPage
{
	private readonly IMyService _myService; // field for the service
	public StartPage(IMyService myService)
	{
		InitializeComponent();
		_myService = myService;

		var message = _myService.GetMessage();
		MyLabel.Text = message;
	}
}

