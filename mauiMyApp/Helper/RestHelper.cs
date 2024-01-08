﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using mauiMyApp.Interface;
using Newtonsoft.Json;

namespace mauiMyApp.Helper
{
    public class RestHelper: IRestService
    {
        private readonly HttpClient client;
        public RestHelper()
        {
            client = new HttpClient();
        }

        public async Task<string> Get(string url)
        {
            Console.WriteLine(url);
            Uri uri = new Uri(string.Format(url, string.Empty)); ;
            string content = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }
                else
                {

                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return content;
        }

    }
}

