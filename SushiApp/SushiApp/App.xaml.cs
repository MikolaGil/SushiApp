using SushiApp.API;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SushiApp
{
    public partial class App : Application
    {
        public const string SushiData = "sushi.db";
        public static SushiRepository database;
        public static SushiRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new SushiRepository(SushiData);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainPage());
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
