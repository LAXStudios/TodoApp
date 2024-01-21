namespace TodoApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		if (VersionTracking.IsFirstLaunchForCurrentVersion)
		{
            MainPage = new AppShell();
		}
		else
		{
			MainPage = new AppShell();
		}

		
	}
}
