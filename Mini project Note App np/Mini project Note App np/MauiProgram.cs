using Microsoft.Extensions.Logging;

namespace Mini_project_Note_App_np;

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

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<NotePage>();
		builder.Services.AddSingleton<NoteViewModel>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
