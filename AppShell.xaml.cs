namespace TodoApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(NewHomeWorkPage), typeof(NewHomeWorkPage));
	}
}
