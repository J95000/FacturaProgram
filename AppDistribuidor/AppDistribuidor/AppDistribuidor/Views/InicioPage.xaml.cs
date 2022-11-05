using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDistribuidor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
        }

        private async void BtnClientes_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AboutPage());
        }

        private async void BtnPedidos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPage2());
        }

        private async void BtnGastos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemPage3());
        }

        private async void BtnStock_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StockPage());
        }

        private async void BtnVentas_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ItemsPage());
        }
    }
}