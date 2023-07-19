using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Mopups.Hosting;
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
			.ConfigureMopups()
			.UseBottomSheet() 
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

                static void MakeStatusBarTranslucent(Android.App.Activity activity)
                {
                    activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);

                    activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);

                    activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                }
#endif
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainPageViewModel>();

		builder.Services.AddSingleton<HomeWorkPage>();
		builder.Services.AddSingleton<HomeWorkViewModel>();

		builder.Services.AddSingleton<NewHomeWorkPage>();
		builder.Services.AddSingleton<NewHomeWorkViewModel>();

		builder.Services.AddSingleton<DetailHomeWorkPopUp>();
		builder.Services.AddSingleton<DetailsPopUpViewModel>();

		builder.Services.AddSingleton<HomeWorkDetailsButtomSheet>();
		builder.Services.AddSingleton<HomeWorkDetailsBottomSheetViewModel>();

		builder .Services.AddSingleton<LifeManagerPage>();
		builder .Services.AddSingleton<LifeManangerViewModel>();

		builder.Services.AddSingleton<ShoppingListPage>();
		builder.Services.AddSingleton<ShoppingListViewModel>();


		builder.Services.AddSingleton<ILiteDBService, LiteDBService>();
		builder.Services.AddSingleton<IHomeWorkService, HomeWorkService>();

        return builder.Build();
	}
}
