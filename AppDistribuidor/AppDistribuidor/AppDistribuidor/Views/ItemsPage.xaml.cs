﻿using AppDistribuidor.Models;
using AppDistribuidor.ViewModels;
using Plugin.Connectivity;
using AppDistribuidor.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AppDistribuidor.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;
        
        List<string> clientes;
        int idCliente = 0;
        public ItemsPage()
        {
            InitializeComponent();
            //clientes = new List<string>();
            //ListarClientes();
            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            //VariablesGlobales.Total = 0;
            //TxtTotal.Text = "0";
        }

        //public static async Task<List<EClienteCorta>> Obtener_Cliente()
        //{
        //    var client = new HttpClient();
        //    var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Cliente");
        //    string resp = Convert.ToString(responseString);
        //    var obj = JsonConvert.DeserializeObject<object>(resp);
        //    string data = Convert.ToString(obj);
        //    List<EClienteCorta> eUsuarioCompleja = new List<EClienteCorta>();
        //    eUsuarioCompleja = JsonConvert.DeserializeObject<List<EClienteCorta>>(data);
        //    return eUsuarioCompleja;

        //}
        public static async Task<ECliente> Obtener_Cliente_Buscador_NombreCompleto(string nombre)
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Cliente_Buscador_NombreCompleto/" + nombre);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            ECliente eUsuarioCompleja = new ECliente();
            eUsuarioCompleja = JsonConvert.DeserializeObject<ECliente>(data);
            return eUsuarioCompleja;

        }
        public  List<EClienteCorta> Obtener_Cliente()
        {
            var client = new HttpClient();
            var responseString = client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Cliente");
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            List<EClienteCorta> eUsuarioCompleja = new List<EClienteCorta>();
            eUsuarioCompleja = JsonConvert.DeserializeObject<List<EClienteCorta>>(data);
            return eUsuarioCompleja;

        }

        public void ListarClientes()
        {
            clientes = new List<string>();

            SWNegocio.SWNegocioAquacorpClient cliente = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);

            List<SWNegocio.EClienteCompleja> eClienteComplejas = cliente.Obtener_Cliente().ToList();

            //List<EClienteCorta> eClienteComplejas = Task.Run(() => Obtener_Cliente()).GetAwaiter().GetResult();


            foreach (SWNegocio.EClienteCompleja item in eClienteComplejas)
            {
                clientes.Add(item.Nombres + " " + item.PrimerApellido + " " + item.SegundoApellido);
            }

        }


        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(busca.Text))
            {
                //ListarClientes();
                searchResults.IsVisible = true;
                searchResults.BeginRefresh();
                // searchResults.ItemsSource = clientes.Where(i => i.ToUpper().StartsWith(e.NewTextValue.ToUpper()));
                //searchResults.ItemsSource = clientes;
                searchResults.ItemsSource = _viewModel.Clientess.Where(i => i.NombreCompleto.ToUpper().StartsWith(e.NewTextValue.ToUpper()));
                searchResults.EndRefresh();
            }
            else
            {
                searchResults.IsVisible = false;
            }
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


        private void searchResults_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(CheckConexion())
            {


         
            EClienteNombres listsd = e.Item as EClienteNombres;
            _viewModel.NombreCliente = listsd.NombreCompleto;

            //busca.Text = listsd.NombreCompleto;
            searchResults.IsVisible = false;
            //SWNegocio.SWNegocioAquacorpClient cliente = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);
            //SWNegocio.EClienteCompleja clienteCompleja = cliente.Obtener_Cliente_Buscador_NombreCompleto(listsd);

            ECliente clienteCompleja = Task.Run(() => Obtener_Cliente_Buscador_NombreCompleto(listsd.NombreCompleto)).GetAwaiter().GetResult();
            idCliente = clienteCompleja.IdCliente;
            
            
            ((ListView)sender).SelectedItem = null;

            }

        }


        public static async Task<bool> Insertar_Movimiento(EMovimiento eEMovimiento)
        {

            using (HttpClient cliente = new HttpClient())
            {
                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                //POST Request
                string requestUrl = "http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/InsertarMovimiento";


                string jsonString = JsonConvert.SerializeObject(eEMovimiento, microsoftDateFormatSettings);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = cliente.PostAsync(requestUrl, request).Result;
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (result == "true") return true;
                else return false;
            }


        }
        public static async Task<int> Obtener_Ultimo_IdMovimiento()
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Ultimo_IdMovimiento");
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            int eUsuarioCompleja = new int();
            eUsuarioCompleja = JsonConvert.DeserializeObject<int>(data);
            return eUsuarioCompleja;

        }

        public static async Task<bool> InsertarDetalleMovimiento( EDetalleMovimiento eDetalleMovimiento)
        {

            using (HttpClient cliente = new HttpClient())
            {
                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                //POST Request
                string requestUrl = "http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/InsertarDetalleMovimiento";


                string jsonString = JsonConvert.SerializeObject(eDetalleMovimiento, microsoftDateFormatSettings);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = cliente.PostAsync(requestUrl, request).Result;
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (result == "true") return true;
                else return false;
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                //VALIDAR SI HAY UN CLIENTE QUE SU NOMBRE EXISTA

                if (CheckConexion())
                {



                    if (!String.IsNullOrWhiteSpace(busca.Text))
                    {
                        if (_viewModel.Productos.Count > 0)
                        {
                            EMovimiento eMovimientoCompleja = new EMovimiento()
                            {

                                Codigo = "",
                                Cont = 1,
                                Estado = "HA",
                                FechaModificacion = DateTime.Now,
                                FechaRegistro = DateTime.Now,
                                IdCliente = idCliente,
                                IdMovimiento = 1,
                                IdUsuario = VariablesGlobales.IdUsuario,
                                NombreCliente = "",
                                NombreUsuario = "",
                                TipoMovimiento = "VENTA"


                            };


                            bool res = await Insertar_Movimiento(eMovimientoCompleja);
                            // sWNegocioAquacorpClient.Insertar_Movimiento(eMovimientoCompleja);
                            if (res)
                            {
                                int idMovi = await Obtener_Ultimo_IdMovimiento();
                                //int idMovi = sWNegocioAquacorpClient.Obtener_Ultimo_IdMovimiento();

                                var itt = _viewModel.Productos;
                                var indice = 1;
                                foreach (var item in itt)
                                {
                                    EDetalleMovimiento eDetalleMovimientoCompleja = new EDetalleMovimiento()
                                    {

                                        Cantidad = item.Cantidad,
                                        Cont = 1,
                                        Estado = "HA",
                                        IdDetalleMovimiento = 1,
                                        IdMovimiento = idMovi,
                                        IdProducto = item.IdProducto,
                                        NombreProducto = "",
                                        PrecioUnitario = item.Precio,
                                        FechaModificacion = DateTime.Now,
                                        FechaRegistro = DateTime.Now,

                                    };

                                    bool ress = await InsertarDetalleMovimiento(eDetalleMovimientoCompleja);
                                    //  sWNegocioAquacorpClient.Insertar_DetalleMovimiento(eDetalleMovimientoCompleja);
                                    if (ress)
                                    {
                                        if(itt.Count == indice)
                                        {
                                            await DisplayAlert("Venta", "Venta Registrada con exito.", "Ok");
                                            byte[] pdf = _viewModel.GenerarPdf(eMovimientoCompleja, eDetalleMovimientoCompleja);
                                            _viewModel.EnviarCorreo("axel20ayalam@gmail.com", "eddymartinez2022@gmail.com", pdf);
                                        }
                                    }
                                    else
                                    {
                                        new Exception();
                                    }
                                    indice++;
                                }


                            }
                            else
                            {
                                await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                            }

                            BindingContext = null;
                            // InitializeComponent();

                            //ListarClientes();
                            busca.Text = String.Empty;
                            _viewModel.Productos.Clear();
                            _viewModel.BorrarTodo();
                            BindingContext = _viewModel = new ItemsViewModel();

                        }
                        else
                        {
                            await DisplayAlert("Productos", "Seleccione un producto para venta.", "Ok");
                        }

                    }
                    else
                    {
                        await DisplayAlert("Cliente", "Seleccione un cliente.", "Ok");
                    }
                }
            
            }
            catch (Exception ex)
            {

                await DisplayAlert("Venta", "Problema al registrar venta.\n " + ex.Message, "Ok");
            }
        }


    }
}