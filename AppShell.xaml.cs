using TodoApp.Pages;

namespace TodoApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(NewHomeWorkPage), typeof(NewHomeWorkPage));
		Routing.RegisterRoute(nameof(ShoppingListPage), typeof(ShoppingListPage));
		Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
		Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
		Routing.RegisterRoute(nameof(LongTodoCreatePage), typeof(LongTodoCreatePage));
	}
}
