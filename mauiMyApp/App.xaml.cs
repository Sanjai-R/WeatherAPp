using System;
using Microsoft.Maui.Controls.Xaml;
using System.IO;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using mauiMyApp.Helper;
using mauiMyApp.View;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace mauiMyApp
{
    public partial class App : Application
    {
        //public static DbHelper db;
        //public const string DatabaseFilename = "TestSQlite.db3";

        //public static DbHelper MyDb
        //{
        //    get
        //    {
        //        if (db == null)
        //        {
        //            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        //            db = new DbHelper(Path.Combine(basePath, DatabaseFilename));
        //        }
        //        return db;
        //    }

        //}

        public App()
        {
            InitializeComponent();

            MainPage = new RegisterPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
