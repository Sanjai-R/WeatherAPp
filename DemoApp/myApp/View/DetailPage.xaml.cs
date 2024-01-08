using System;
using System.Collections.Generic;
using DemoApp.Constants;
using DemoApp.Helper;
using DemoApp.Model;
using DemoApp.Service;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace DemoApp
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage()
		{
			InitializeComponent();

		}

		protected override async void OnAppearing()
		{
			try
			{
				base.OnAppearing();

                Location location = await Geolocation.GetLastKnownLocationAsync();
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
                loc.Text = location.Latitude.ToString();
                WeatherService weatherService = new WeatherService();
                Root weatherData = await weatherService.getWeatherByCity(location.Latitude.ToString(), location.Longitude.ToString());
                BindingContext = weatherData;

            }
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		private async void GetLocationData()
		{
			try
			{
				var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

				if (status != PermissionStatus.Granted)
				{
					status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
					Console.WriteLine("Granted");
				}

				if (status == PermissionStatus.Granted)
				{
					Location location = await Geolocation.GetLastKnownLocationAsync();
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                    loc.Text = location.Latitude.ToString();
                    WeatherService weatherService = new WeatherService();
                    Root weatherData = await weatherService.getWeatherByCity(location.Latitude.ToString(),location.Longitude.ToString());
                    BindingContext = weatherData;
                    
                }
				else
				{
					// Handle the case where the user denied location permissions
					Console.WriteLine("Location permission denied");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}


		void Button_Clicked(System.Object sender, System.EventArgs e)
		{
			GetLocationData();
		}
	}
}

