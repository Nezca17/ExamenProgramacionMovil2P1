using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using PM02E16533.Controllers;

namespace PM02E16533
{
    public partial class App : Application
    {

        static DBSitios db;

        public static DBSitios DBase
        {
            get
            {
                //se declara la ruta donde estan los archivos de la BD
                if (db == null)
                {
                    String FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EmpleDB.db3");//db3 es extencion de sqlite
                    db = new DBSitios(FolderPath);
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
