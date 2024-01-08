using mauiMyApp.Helper;
using Microsoft.Extensions.Logging;
using mauiMyApp.Interface;
using DemoApp.Service;

namespace mauiMyApp;

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

		builder.Services.AddSingleton<ISqliteDb, SqliteDb>();
		builder.Services.AddSingleton<IWeatherService, WeatherService>();
		builder.Services.AddSingleton<IRestService, RestHelper>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

