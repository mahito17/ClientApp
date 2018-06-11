using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClientApp.View;
using ClientApp.Data;
using ClientApp.Services;

namespace ClientApp
{
    public partial class App : Application
    {
        private static ClientDatabase database;

        public static ClientDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ClientDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePatch("clientsdb.db3"));
                }

                return database;

            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
