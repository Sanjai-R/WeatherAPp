using System;
using mauiMyApp.Model;

namespace mauiMyApp.Interface
{  
        public interface IWeatherService
        {
            Task<Root> GetWeatherByCity(string lat, string longi);
            void GetUsers();
        }
}

