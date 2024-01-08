using System;
namespace mauiMyApp.Constants
{
	public class Constant
	{

		public static string apiUrl = "https://jsonplaceholder.typicode.com/posts";
		public static string baseUrl  = "https://api.openweathermap.org/data/2.5";
		public static string weatherApiUrl = $"{baseUrl}/weather";
		public static string apiKey = "ac821a8e745023d66c258bb6410700b7";


        public const string DatabaseFilename = "TestSQlite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
       Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}

