using System;
using mauiMyApp.Constants;

namespace mauiMyApp.Helper
{
	public static class Utils
	{
		
		public static string buildCityWeatherUrl(string lat,string longi)
		{
            var url = $"{Constant.weatherApiUrl}?appid={Constant.apiKey}&lat={lat}&lon={longi}";
			return url;
		}
	}
}

