using Android.App;
using Android.Runtime;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

using TodoApp.Handler;

namespace TodoApp;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

    protected override MauiApp CreateMauiApp()
    {
        // Remove Entry control underline
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry.HasUnderline), (h, v) =>
        {
            h.PlatformView.BackgroundTintList =
                Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
        });

        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(("HasUnderline"), (handler, view) =>
        {
            handler.PlatformView.BackgroundTintList =
                Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
        });

        Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping(("HasUnderline"), (handler, view) =>
        {
            handler.PlatformView.BackgroundTintList =
                Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
        });

        return MauiProgram.CreateMauiApp();
    }
}
