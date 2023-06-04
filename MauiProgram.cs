using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TodoApp.Pages;

namespace TodoApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainPageViewModel>();

		builder.Services.AddSingleton<HomeWorkPage>();
		builder.Services.AddSingleton<HomeWorkViewModel>();

		builder.Services.AddSingleton<NewHomeWorkPage>();
		builder.Services.AddSingleton<NewHomeWorkViewModel>();

		builder.Services.AddSingleton<ILiteDBService, LiteDBService>();
		builder.Services.AddSingleton<IHomeWorkService, HomeWorkService>();
#endif

        return builder.Build();
	}
}
