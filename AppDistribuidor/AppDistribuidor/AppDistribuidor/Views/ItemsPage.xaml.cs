using AppDistribuidor.Models;
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
using System.Collections.ObjectModel;
using AppDistribuidor.Facturacion;


namespace AppDistribuidor.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;
        GenerarFactura generarFactura;
        EnvioCorreo envioCorreo;
        List<string> clientes;
        int idCliente = 0;
        ECliente clienteCompleja;
        string NombreCliente = "";


        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ItemsViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
           // byte valor = VariablesGlobales.TipoRegistroCliente;
            LlenarClienteRegistrado();
            clienteCompleja = new ECliente();
        }

        public void LlenarClienteRegistrado()
        {
            if (VariablesGlobales.TipoRegistroCliente == 1)
            {
                busca.Text= VariablesGlobales.NombreClienteRegistrado;
            }
        }
  
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

        public async Task<EDosificacionCompleja> Obtener_Dosificacion_Habilitado()
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Dosificacion_Habilitado");
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            EDosificacionCompleja eDosificacionCompleja = new EDosificacionCompleja();
            eDosificacionCompleja = JsonConvert.DeserializeObject<EDosificacionCompleja>(data);
            return eDosificacionCompleja;
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

        public async Task<List<EClienteBuscador>> Get_Cliente_Buscador_Async(string nombre)
        {
            List<EClienteBuscador> listClientes = new List<EClienteBuscador>();
            var client = new HttpClient();
            HttpResponseMessage responseString = await client.GetAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Cliente_Buscador" + "/" + nombre);
            
            DoIndependentWork();
          

            if (responseString.IsSuccessStatusCode)
            {
                string content = await responseString.Content.ReadAsStringAsync();
                var obje = JsonConvert.DeserializeObject<object>(content);
                string datas = Convert.ToString(obje);

                return JsonConvert.DeserializeObject<List<EClienteBuscador>>(datas);

            }
            return listClientes;



            //string resp = Convert.ToString(responseString);
            //var obj = JsonConvert.DeserializeObject<object>(resp);
            //string data = Convert.ToString(obj);
           
            //listClientes = JsonConvert.DeserializeObject<List<EClienteBuscador>>(data);
            //return listClientes;

        }

        //public async Task<List<EClienteBuscador>> ObtenerDatosCliente(string nombre)
        //{
        //    List<EClienteBuscador> listClientes = new List<EClienteBuscador>();
        //    var client = new HttpClient();
        //    HttpResponseMessage responseString = await client.GetAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Cliente_Buscador" + "/" + nombre);

        //    DoIndependentWork();


        //    if (responseString.IsSuccessStatusCode)
        //    {
        //        string content = await responseString.Content.ReadAsStringAsync();
        //        var obje = JsonConvert.DeserializeObject<object>(content);
        //        string datas = Convert.ToString(obje);

        //        return JsonConvert.DeserializeObject<List<EClienteBuscador>>(datas);

        //    }
        //    return listClientes;

        //}


        public void DoIndependentWork()
        {
            Console.WriteLine("Working...");
            Task.Delay(1000);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine($"-----SE BUSCA EL CLIENTE ==    " + busca.Text + "-----");
            ObservableCollection<EClienteNombres> eClienteNombres = new ObservableCollection<EClienteNombres>();
            if (!String.IsNullOrWhiteSpace(busca.Text))
            {
                List<EClienteBuscador> listClientes = Task.Run(() => Get_Cliente_Buscador_Async(busca.Text)).GetAwaiter().GetResult();

                foreach (EClienteBuscador item in listClientes)
                {
                    EClienteNombres eClienteNombres1 = new EClienteNombres()
                    {
                        NombreCompleto = item.Nombrecompleto
                    };
                    eClienteNombres.Add(eClienteNombres1); 
                }
                searchResults.IsVisible = true;
                searchResults.BeginRefresh();
                var query = from c in listClientes select c.Nombrecompleto;


                searchResults.ItemsSource = eClienteNombres.Where(i => i.NombreCompleto.ToUpper().StartsWith(e.NewTextValue.ToUpper()));
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
                NombreCliente= listsd.NombreCompleto;
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


        public static async Task<bool> Insertar_Movimiento_SinFactura(EMovimiento eEMovimiento)
        {

            using (HttpClient cliente = new HttpClient())
            {
                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                //POST Request
                string requestUrl = "http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Insertar_Movimiento_SinFactura";


                string jsonString = JsonConvert.SerializeObject(eEMovimiento, microsoftDateFormatSettings);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = cliente.PostAsync(requestUrl, request).Result;
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (result == "true") return true;
                else return false;
            }


        }

        public static async Task<bool> Insertar_Movimiento_ConFactura(EMovimiento eEMovimiento)
        {

            using (HttpClient cliente = new HttpClient())
            {
                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                //POST Request
                string requestUrl = "http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Insertar_Movimiento_ConFactura";


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

        public static async Task<bool> InsertarDetalleMovimiento(EDetalleMovimiento eDetalleMovimiento)
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
        public static async Task<bool> InsertarActualizarCliente(EClienteActualizarCorta eCliente)
        {

            using (HttpClient cliente = new HttpClient())
            {
                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                //POST Request
                string requestUrl = "http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Actualizar_Cliente_Corta";


                string jsonString = JsonConvert.SerializeObject(eCliente, microsoftDateFormatSettings);
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
                if (CheckConexion())
                {
                    if (!String.IsNullOrWhiteSpace(busca.Text))
                    {
                        if (_viewModel.Productos.Count > 0)
                        {

                            clienteCompleja = Task.Run(() => Obtener_Cliente_Buscador_NombreCompleto(NombreCliente)).GetAwaiter().GetResult();

                            string factura = await DisplayActionSheet("Facturación", "Si", "No", "Se requiere factura?.");
                           
                            Console.WriteLine("Action:::::::::::: " + factura);

                            if (factura == "Si")
                            {
                               string razon = clienteCompleja.RazonSocial;
                               string nit = clienteCompleja.NitCi;

                                string RazonNit = await DisplayActionSheet("Datos Para factura", "Si", "Modificar", "Razon Social : " + razon + " \n NitCi : " + nit);


                                if (RazonNit == "Si")
                                {
                                    EDosificacionCompleja eDosificacionCompleja = new EDosificacionCompleja();
                                    eDosificacionCompleja = Task.Run(() => Obtener_Dosificacion_Habilitado()).GetAwaiter().GetResult();

                                    EClienteActualizarCorta clienteCorta = new EClienteActualizarCorta()
                                    {
                                        FotoUbicacion = clienteCompleja.FotoUbicacion,
                                        RazonSocial = razon,
                                        NitCi = nit,
                                        IdCliente = clienteCompleja.IdCliente
                                    };

                                    bool actualizaCli = await InsertarActualizarCliente(clienteCorta);


                                    if (actualizaCli)
                                    {
                                        //SE REGISTRA CON LOS DATOS ACTUALES
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
                                            TipoMovimiento = "VENTA",

                                            PrecioTotal = VariablesGlobales.Total,
                                            ///////////////////////////////////////////////////
                                            IdDosificacion = eDosificacionCompleja.IdDosificacion,
                                            NroMovimiento = eDosificacionCompleja.NroFinalFactura,
                                            CodigoControl = CodigoControl.generateControlCode(eDosificacionCompleja.NroAutorizacion, eDosificacionCompleja.NroFinalFactura.ToString(), "8934674", DateTime.Now.ToString("yyyyMMdd"), VariablesGlobales.Total.ToString("0.00"), eDosificacionCompleja.LlaveDosificacion),
                                            RazonSocial = razon,
                                            NitCi = nit
                                            //////////////////////////////////////////////////////
                                        };
                                        
                                        bool res = await Insertar_Movimiento_ConFactura(eMovimientoCompleja);

                                        if (res)
                                        {
                                            int idMovi = await Obtener_Ultimo_IdMovimiento();

                                            var indice = 1;
                                            var itt = _viewModel.Productos;
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
                                                    PrecioUnitario = item.Precio,
                                                    FechaModificacion = DateTime.Now,
                                                    FechaRegistro = DateTime.Now,
                                                    SubTotal = (item.Cantidad * item.Precio)
                                                };

                                                bool ress = await InsertarDetalleMovimiento(eDetalleMovimientoCompleja);


                                                if (ress)
                                                {
                                                    if (itt.Count == indice)
                                                    {
                                                        generarFactura = new GenerarFactura();
                                                        envioCorreo = new EnvioCorreo();
                                                        byte[] pdf = generarFactura.GenerarPdf(itt, eMovimientoCompleja, eDetalleMovimientoCompleja, eDosificacionCompleja);
                                                        string correo = "rodrigo.iriarte14@gmail.com";//clienteCompleja.CorreoElectronico;
                                                        await DisplayAlert("Venta", "Venta Registrada con exito.", "Ok");
                                                        envioCorreo.EnviarCorreo("AquacorpSanAntonioSRL@gmail.com", correo, pdf);

                                                    }
                                                }
                                                else
                                                {
                                                    await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                                                    // new Exception();
                                                }
                                                indice++;

                                            }


                                        }
                                        else
                                        {
                                            await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                                        }
                                    }
                                    else
                                    {
                                        await DisplayAlert("Cliente", "Problema al actualizar datos de cliente.", "Ok");
                                    }
                                }
                                else
                                {
                                    EDosificacionCompleja eDosificacionCompleja = new EDosificacionCompleja();
                                    eDosificacionCompleja = Task.Run(() => Obtener_Dosificacion_Habilitado()).GetAwaiter().GetResult();

                                    string nuevoRazonSocial = await DisplayPromptAsync("Nueva Razon Social", "");
                                    string nuevoNit = await DisplayPromptAsync("Nuevo Nit o Ci", "");



                                    EClienteActualizarCorta clienteCorta = new EClienteActualizarCorta()
                                    {
                                        FotoUbicacion = clienteCompleja.FotoUbicacion,
                                        RazonSocial = nuevoRazonSocial,
                                        NitCi = nuevoNit,
                                        IdCliente = clienteCompleja.IdCliente

                                    };

                                    bool actualizaCli = await InsertarActualizarCliente(clienteCorta);


                                    if (actualizaCli)
                                    {
                                        //SE REGISTRA CON LOS DATOS ACTUALES
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
                                            TipoMovimiento = "VENTA",

                                            PrecioTotal = VariablesGlobales.Total,
                                            ///////////////////////////////////////////////////
                                            IdDosificacion = eDosificacionCompleja.IdDosificacion,
                                            NroMovimiento = eDosificacionCompleja.NroFinalFactura,
                                            CodigoControl = CodigoControl.generateControlCode(eDosificacionCompleja.NroAutorizacion, eDosificacionCompleja.NroFinalFactura.ToString(), "8934674", DateTime.Now.ToString("yyyyMMdd"), VariablesGlobales.Total.ToString("0.00"), eDosificacionCompleja.LlaveDosificacion),
                                            RazonSocial = nuevoRazonSocial,
                                            NitCi = nuevoNit
                                            //////////////////////////////////////////////////////
                                        };

                                        bool res = await Insertar_Movimiento_ConFactura(eMovimientoCompleja);

                                        if (res)
                                        {
                                            int idMovi = await Obtener_Ultimo_IdMovimiento();

                                            var indice = 1;
                                            var itt = _viewModel.Productos;
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
                                                    PrecioUnitario = item.Precio,
                                                    FechaModificacion = DateTime.Now,
                                                    FechaRegistro = DateTime.Now,
                                                    SubTotal = (item.Cantidad * item.Precio)
                                                };

                                                bool ress = await InsertarDetalleMovimiento(eDetalleMovimientoCompleja);


                                                if (ress)
                                                {
                                                    if (itt.Count == indice)
                                                    {
                                                        generarFactura = new GenerarFactura();
                                                        envioCorreo = new EnvioCorreo();
                                                        byte[] pdf = generarFactura.GenerarPdf(itt, eMovimientoCompleja, eDetalleMovimientoCompleja, eDosificacionCompleja);
                                                        string correo = clienteCompleja.CorreoElectronico;
                                                        await DisplayAlert("Venta", "Venta Registrada con exito.", "Ok");
                                                        envioCorreo.EnviarCorreo("AquacorpSanAntonioSRL@gmail.com", correo, pdf);

                                                    }
                                                }
                                                else
                                                {
                                                    await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                                                    // new Exception();
                                                }
                                                indice++;

                                            }


                                        }
                                        else
                                        {
                                            await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                                        }
                                    }
                                    else
                                    {
                                        await DisplayAlert("Cliente", "Problema al actualizar datos de cliente.", "Ok");
                                    }


                                }

                            }
                            else
                            {
                                //SE REGISTRA SIN FACTURA
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
                                    TipoMovimiento = "VENTA",

                                    PrecioTotal = VariablesGlobales.Total,
                                    IdDosificacion = 0,
                                    NroMovimiento = 0,
                                    CodigoControl = "",
                                    RazonSocial = "",
                                    NitCi = ""
                                };

                                bool res = await Insertar_Movimiento_SinFactura(eMovimientoCompleja);


                                if (res)
                                {
                                    int idMovi = await Obtener_Ultimo_IdMovimiento();

                                    var itt = _viewModel.Productos;
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
                                            PrecioUnitario = item.Precio,
                                            FechaModificacion = DateTime.Now,
                                            FechaRegistro = DateTime.Now,
                                            SubTotal = (item.Cantidad * item.Precio)
                                        };

                                        bool ress = await InsertarDetalleMovimiento(eDetalleMovimientoCompleja);

                                        if (ress)
                                        {
                                            await DisplayAlert("Venta", "Venta Registrada con exito.", "Ok");
                                        }
                                        else
                                        {
                                            await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                                        }
                                    }


                                }
                                else
                                {
                                    await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                                }
                            }


                            // BindingContext = null;



                            busca.Text = String.Empty;
                            Console.WriteLine($"-----BUCAR CLIENTE LIMPIAR-----");
                            _viewModel.Productos.Clear();
                            Console.WriteLine($"-----PRODUCTOS LIMPIAR-----");
                            _viewModel.BorrarTodo();
                            Console.WriteLine($"-----BORRAR TODO  LIMPIAR-----");
                            // BindingContext = _viewModel = new ItemsViewModel();

                        }
                        else
                        {
                            await DisplayAlert("Productos", "Seleccione un producto para venta.", "Ok");
                        }
                    }
                    else
                    {
                        //PARA HACER MODEL CON MENU
                       string action = await DisplayActionSheet("Cliente", "Seleccionar", "Registrar Nuevo", "Se requiere un cliente.");
                       
                         Console.WriteLine("Action:::::::::::: " + action);
                        if (action == "Registrar Nuevo")
                        {
                            VariablesGlobales.TipoRegistroCliente = 1;
                            await Navigation.PushAsync(new AboutPage());
                           
                        }
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