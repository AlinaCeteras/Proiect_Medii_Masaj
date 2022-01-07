using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proiect_Medii_Masaj.Data;
using System.IO;

namespace Proiect_Medii_Masaj
{
    public partial class App : Application
    {
        static AppointmentListDatabase database;
        public static AppointmentListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AppointmentListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AppointmentList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginUI());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
