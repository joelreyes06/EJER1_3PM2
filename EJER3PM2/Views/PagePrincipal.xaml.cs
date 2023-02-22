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
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private void listadatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var elemento = e.CurrentSelection.FirstOrDefault() as Models.Datos;

            if (elemento != null)
            {
                Navigation.PushAsync(new PageUpdateDelete
                {
                    BindingContext = elemento
                });
            }

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listadatos.ItemsSource = await App.DBdatos.ListaDatos();
        }

        private async void toolagrega_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageDatos());
            
        }
    }
}