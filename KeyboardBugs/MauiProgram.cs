#if ANDROID
using Android.App;
using Android.Text;
using Microsoft.Maui.Handlers;
#endif
namespace KeyboardBugs;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
#if ANDROID
            WindowHandler.Mapper.AppendToMapping("CustomWindow", (handler, view) =>
            {
	            if (view is not Window window) return;
				handler.PlatformView.Window?.SetSoftInputMode(Android.Views.SoftInput.AdjustPan);

            });
#endif
		return builder.Build();
	}
}
