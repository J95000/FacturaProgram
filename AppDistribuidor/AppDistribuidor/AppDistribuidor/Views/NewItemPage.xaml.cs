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
using Plugin.Connectivity;

namespace AppDistribuidor.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        int idProducto = 0;
        int idPrecio = 0;
        public NewItemPage()
        {
            InitializeComponent();

            BindingContext = new NewItemViewModel();
            LlenarProductos();
            //VariablesGlobales.Conta = 0;
        }
        public bool CheckConexion()
        {
            bool ban = false;
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    ban = true;
                }
                else
                {
                    DisplayAlert("Conexión a Internet", "No existe una conexion a Internet. \n Por favor Conectese a internet eh intente de nuevo.", "OK");
                    ban = false;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Ocurrio un problema al verificar conexion a internet.\n " + ex.Message, "OK");

            }
            return ban;

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
        public  void LlenarProductos()
        {
            try
            {
                //SWNegocio.SWNegocioAquacorpClient client = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);
                if(CheckConexion())
                {


               
                List<EProductoCorta> eProductoComplejas = Task.Run(() => Obtener_Producto()).GetAwaiter().GetResult();
                DdlstProducto.ItemsSource = eProductoComplejas;
                DdlstProducto.ItemDisplayBinding = new Binding("NombreProducto");
                }
            }
            catch (Exception ex)
            {
                CrossToastPopUp.Current.ShowToastMessage("Problema al obtener lista de productos. \n " + ex.Message);
                //await DisplayAlert("Prestamo", "Problema al registrar Prestamo.", "Ok");
            }
        }
        public static async Task<List<EPrecioSugerido>> Obtener_PrecioSugerido_IdProducto(string idProducto)
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_PrecioSugerido_IdProducto/"+ idProducto);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            List<EPrecioSugerido> eUsuarioCompleja = new List<EPrecioSugerido>();
            eUsuarioCompleja = JsonConvert.DeserializeObject<List<EPrecioSugerido>>(data);
            return eUsuarioCompleja;

        }
        public  void LlenarPrecios()
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
        private  void DdlstProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

               // var selectedProducto = DdlstProducto.SelectedItem as SWNegocio.EProductoCompleja;

                var selectedProducto = DdlstProducto.SelectedItem as EProductoCorta;
                idProducto = selectedProducto.IdProducto;
                 TxtIdProdu.Text= selectedProducto.IdProducto.ToString();
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

                //var selectedPrecio = DdlstPrecio.SelectedItem as SWNegocio.EPrecioSugeridoCompleja;

                var selectedPrecio = DdlstPrecio.SelectedItem as EPrecioSugerido;
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