using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using mauiMyApp.Helper;
using mauiMyApp.Interface;
using mauiMyApp.Model;
using Newtonsoft.Json;

namespace DemoApp.Service
{
    public class WeatherService : IWeatherService
    {
        private readonly IRestService _client;
        private readonly ISqliteDb localDb;

        public WeatherService(ISqliteDb sqliteDb, IRestService client)
        {
            _client = client;
            localDb = sqliteDb;
        }

        public async Task<Root> GetWeatherByCity(string lat, string longi)
        {
            var url = Utils.buildCityWeatherUrl(lat, longi);
           
            var content = await _client.Get(url);
            var response = JsonConvert.DeserializeObject<Root>(content);
            return response;
        }

        public async void GetUsers()
        {
            List<UserModel> listOfUsers = await localDb.GetUsers();

            listOfUsers.ForEach(x => Console.WriteLine(x.email));

        }


    }
}

