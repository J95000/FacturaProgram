using AppDistribuidor.Models;
using AppDistribuidor.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDistribuidor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevoGastoPage : ContentPage
    {
        public EGasto Gasto { get; set; }
        public NuevoGastoPage()
        {
            InitializeComponent(); 
            BindingContext = new NuevoGastoModel();
            LlenarTipoGasto();
        
        }
        public static async Task<List<ETipoGasto>> Obtener_TipoGasto_Distribuccion()
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc//Obtener_TipoGasto_Distribuccion");
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            List<ETipoGasto> eProductoCompleja = new List<ETipoGasto>();
            eProductoCompleja = JsonConvert.DeserializeObject<List<ETipoGasto>>(data);
            return eProductoCompleja;

        }
        public void LlenarTipoGasto()
        {
            try
            {
                List<ETipoGasto> eProductoComplejas = Task.Run(() => Obtener_TipoGasto_Distribuccion()).GetAwaiter().GetResult();
                DdlstGasto.ItemsSource = eProductoComplejas;
                DdlstGasto.ItemDisplayBinding = new Binding("NombreTipoGasto");
            }
            catch (Exception)
            {


            }
        }


        private void DdlstGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedProducto = DdlstGasto.SelectedItem as ETipoGasto;
                TxtTipo.Text = selectedProducto.NombreTipoGasto;
                VariablesGlobales.idTipoGasto = selectedProducto.IdTipoGasto;
            }
            catch (Exception)
            {


            }
        }
    }
}