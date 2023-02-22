using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJER3PM2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageUpdateDelete : ContentPage
    {
        public PageUpdateDelete()
        {
            InitializeComponent();
        }
        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            var data = new Models.Datos
            {
                Id = Int32.Parse(id.Text),
                Nombre = nombre.Text,
                Apellidos = apellidos.Text,
                Edad = edad.Text,
                Correo = correo.Text,
                Direccion = direccion.Text
            };

            if (await App.DBdatos.StoreDatos(data) > 0)
            {
                await DisplayAlert("Alerta", "Datos actualizados", "Ok");

                id.Text = "";
                nombre.Text = "";
                apellidos.Text = "";
                edad.Text = "";
                correo.Text = "";
                direccion.Text = "";

                await Navigation.PushAsync(new Views.PagePrincipal());
            }
            else
            {
                await DisplayAlert("Error", "No se pudo actualizar", "Ok");
            }
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            OnAlertYesNoClicked(sender, e);
        }

        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Alerta", "Eliminar Datos?", "Si", "No");

            if (answer == true)
            {
                var data = new Models.Datos
                {
                    Id = Int32.Parse(id.Text)
                };

                if (await App.DBdatos.DeleteDatos(data) > 0)
                {
                    await DisplayAlert("Alerta", "Datos eliminados", "Ok");

                    id.Text = "";
                    nombre.Text = "";
                    apellidos.Text = "";
                    edad.Text = "";
                    correo.Text = "";
                    direccion.Text = "";

                    await Navigation.PushAsync(new Views.PagePrincipal());
                }
                else
                {
                    await DisplayAlert("Error", "No se puede eliminar", "Ok");
                }

            }
        }
    }
}