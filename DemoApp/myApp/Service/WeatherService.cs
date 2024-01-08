using System;
using DemoApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApp.Helper;
using DemoApp.Constants;
using Newtonsoft.Json;

namespace DemoApp.Service
{
    public class WeatherService
    {
       public static RestHelper client;

        public WeatherService()
        {
            client = new RestHelper();
        }

        public async Task<Root> getWeatherByCity(string lat,string longi)
        {
            var url = Utils.buildCityWeatherUrl(lat,longi);
            Console.WriteLine(url);
            var content = await client.Get(url);
            var response = JsonConvert.DeserializeObject<Root>(content);
          
            return response;
        }

    }
}

