using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJER3PM2
{
    public partial class App : Application
    {
        static Controllers.DatosDB dbdatos;

        public static Controllers.DatosDB DBdatos
        {
            get
            {
                if (dbdatos == null)
                {
                    var PathApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var DBName = Models.Configuraciones.DBName;
                    var PathFull = Path.Combine(PathApp, DBName);


                    dbdatos = new Controllers.DatosDB(PathFull);
                }
                return dbdatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PagePrincipal());
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
