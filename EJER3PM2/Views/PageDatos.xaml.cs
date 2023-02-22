using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace EJER3PM2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDatos : ContentPage
    {
        public PageDatos()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var data = new Models.Datos
            {
                Nombre = nombre.Text,
                Apellidos = apellidos.Text,
                Edad = edad.Text,
                Correo = correo.Text,
                Direccion = direccion.Text
            };

            if (await App.DBdatos.StoreDatos(data) > 0)
            {
                await DisplayAlert("Aviso", "Ingresado", "Ok");
                await Navigation.PushAsync(new Views.PagePrincipal());
            }
            else
            {
                await DisplayAlert("Aviso", "No Ingresado", "Ok");
            }


        }
    }
}