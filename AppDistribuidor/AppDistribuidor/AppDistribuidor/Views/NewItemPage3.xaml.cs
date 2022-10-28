using AppDistribuidor.Models;
using AppDistribuidor.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Toast;

namespace AppDistribuidor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage3 : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage3()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel3();
            LlenarGastos();
            VariablesGlobales.Conta = 0;
        }



        public static async Task<List<ETipoGasto>> Obtener_TipoGasto_Distribuccion()
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_TipoGasto_Distribuccion");
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            List<ETipoGasto> eUsuarioCompleja = new List<ETipoGasto>();
            eUsuarioCompleja = JsonConvert.DeserializeObject<List<ETipoGasto>>(data);
            return eUsuarioCompleja;

        }
        public void LlenarGastos()
        {
            try
            {
                //SWNegocio.SWNegocioAquacorpClient client = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);
                //List<SWNegocio.ETipoGastoCompleja> eProductoComplejas = client.Obtener_TipoGasto_Distribuccion().ToList();

                List<ETipoGasto> eProductoComplejas = Task.Run(() => Obtener_TipoGasto_Distribuccion()).GetAwaiter().GetResult();
                DdlstGasto.ItemsSource = eProductoComplejas;
                DdlstGasto.ItemDisplayBinding = new Binding("NombreTipoGasto");

            }
            catch (Exception ex)
            {

                CrossToastPopUp.Current.ShowToastMessage("Problema al obtener lista de tipo gastos. \n " + ex.Message);
            }
        }
        private void DdlstGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idss = DdlstGasto.SelectedItem as ETipoGasto;
            //var idss=  DdlstGasto.SelectedItem as SWNegocio.ETipoGastoCompleja;
            TxtGasto.Text= idss.IdTipoGasto.ToString();
        }
    }
}
