using AppDistribuidor.Models;
using AppDistribuidor.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Plugin.Toast;

namespace AppDistribuidor.Views
{
  
    public partial class NewItemPage2 : ContentPage
    {
        public Item Item { get; set; }
        int idProducto = 0;
        int idPrecio = 0;
     

        public NewItemPage2()
        {
            InitializeComponent();

            BindingContext = new NewItemViewModel2();
            LlenarProductos();
            //VariablesGlobales.Conta = 0;
        }
        public static async Task<List<EProductoCorta>> Obtener_Producto()
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Producto_Mobil");
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            List<EProductoCorta> eUsuarioCompleja = new List<EProductoCorta>();
            eUsuarioCompleja = JsonConvert.DeserializeObject<List<EProductoCorta>>(data);
            return eUsuarioCompleja;

        }
        public void LlenarProductos()
        {
            try
            {
                //SWNegocio.SWNegocioAquacorpClient client = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);
                //List<SWNegocio.EProductoCompleja> eProductoComplejas = client.Obtener_Producto().ToList();
                List<EProductoCorta> eProductoComplejas = Task.Run(() => Obtener_Producto()).GetAwaiter().GetResult();
                DdlstProducto.ItemsSource = eProductoComplejas;
                DdlstProducto.ItemDisplayBinding = new Binding("NombreProducto");

            }
            catch (Exception ex)
            {

                CrossToastPopUp.Current.ShowToastMessage("Problema al obtener lista de productos. \n " + ex.Message);
            }
        }
        public static async Task<List<EPrecioSugerido>> Obtener_PrecioSugerido_IdProducto(string idProducto)
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_PrecioSugerido_IdProducto/" + idProducto);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            List<EPrecioSugerido> eUsuarioCompleja = new List<EPrecioSugerido>();
            eUsuarioCompleja = JsonConvert.DeserializeObject<List<EPrecioSugerido>>(data);
            return eUsuarioCompleja;

        }
        public void LlenarPrecios()
        {
            try
            {
                //SWNegocio.SWNegocioAquacorpClient client = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);
                //List<SWNegocio.EPrecioSugeridoCompleja> eProductoComplejas = client.Obtener_PrecioSugerido_IdProducto(idProducto).ToList();

                List<EPrecioSugerido> eProductoComplejas = Task.Run(() => Obtener_PrecioSugerido_IdProducto(idProducto.ToString())).GetAwaiter().GetResult();
                DdlstPrecio.ItemsSource = eProductoComplejas;
                DdlstPrecio.ItemDisplayBinding = new Binding("Precio");
            }
            catch (Exception ex)
            {
                CrossToastPopUp.Current.ShowToastMessage("Problema al obtener lista de precios. \n " + ex.Message);

            }
        }
        private void DdlstProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedProducto = DdlstProducto.SelectedItem as EProductoCorta;
                
                idProducto = selectedProducto.IdProducto;
                TxtIdProdu.Text = selectedProducto.IdProducto.ToString();
                TxtProducto.Text = selectedProducto.NombreProducto;
                LlenarPrecios();
            }
            catch (Exception ex)
            {
                CrossToastPopUp.Current.ShowToastMessage("Problema al seleccionar un producto. \n " + ex.Message);

            }
        }

        private void DdlstPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedPrecio = DdlstPrecio.SelectedItem as EPrecioSugerido;
                //var selectedPrecio = DdlstPrecio.SelectedItem as SWNegocio.EPrecioSugeridoCompleja;
                idPrecio = selectedPrecio.IdPrecioSugerido;
                TxtPrecio.Text = selectedPrecio.Precio.ToString();
            }
            catch (Exception ex)
            {
                CrossToastPopUp.Current.ShowToastMessage("Problema al seleccionar un precio. \n " + ex.Message);

            }
        }
    }
}
