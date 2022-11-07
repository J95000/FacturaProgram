using AppDistribuidor.Facturacion;
using AppDistribuidor.Models;
using AppDistribuidor.ViewModels;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


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
                busca.Text = VariablesGlobales.NombreClienteRegistrado;
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
        public List<EClienteCorta> Obtener_Cliente()
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

        public async Task<EDosificacionCompleja> Obtener_Dosificacion_IdDosificacion(int IdDosificacion)
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync($"http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Dosificacion_IdDosificacion/{IdDosificacion}");
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
            if (CheckConexion())
            {



                EClienteNombres listsd = e.Item as EClienteNombres;
                _viewModel.NombreCliente = listsd.NombreCompleto;
                NombreCliente = listsd.NombreCompleto;
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
                    //Preguntar si un cliente fue seleccionado
                    if (!String.IsNullOrWhiteSpace(busca.Text))
                    {
                        //Preguntar si el número de productos seleccionados son mas que 0
                        if (_viewModel.Productos.Count > 0)
                        {
                            //Llenando la instancia de cliente con los datos recibidos del metodo Obtener_Cliente_Buscador_NombreCompleto
                            clienteCompleja = Task.Run(() => Obtener_Cliente_Buscador_NombreCompleto(NombreCliente)).GetAwaiter().GetResult();
                            //Preguntar al usuario si va a requerir una factura
                            string factura = await DisplayActionSheet("Facturación", "Si", "No", "Se requiere factura?.");
                            //Escribir en consola la respuesta del usuario
                            Console.WriteLine("Action:::::::::::: " + factura);
                            //Entra al if si requiere factura
                            if (factura == "Si")
                            {
                                //Instancia de la clase EDosificacionCompleja
                                EDosificacionCompleja eDosificacionCompleja = new EDosificacionCompleja();
                                //Llenando la instancia con los datos recibidos del metodo Obtener_Dosificacion_Habilitado
                                eDosificacionCompleja = Task.Run(() => Obtener_Dosificacion_Habilitado()).GetAwaiter().GetResult();

                                string razon = clienteCompleja.RazonSocial;
                                string nit = clienteCompleja.NitCi;
                                //Entra al if si hay una dosificacion vigente
                                if (eDosificacionCompleja.IdDosificacion != 0 && eDosificacionCompleja.FechaLimite > DateTime.Now)
                                {
                                    //Preguntar al usuario si va a requerir modificar la razon social y NIT del cliente
                                    string RazonNit = await DisplayActionSheet("Datos Para factura", "Si", "Modificar", "Razon Social : " + razon + " \n NitCi : " + nit);
                                    //Entra al if si no requiere modificar
                                    if (RazonNit == "Si")
                                    {
                                        //Se incrementa el nroFinalFactura
                                        eDosificacionCompleja.NroFinalFactura++;
                                        //Crear un objeto basado en la clase cliente
                                        EClienteActualizarCorta clienteCorta = new EClienteActualizarCorta()
                                        {
                                            FotoUbicacion = clienteCompleja.FotoUbicacion,
                                            RazonSocial = razon,
                                            NitCi = nit,
                                            IdCliente = clienteCompleja.IdCliente
                                        };
                                        //Actualizar los datos de cliente
                                        bool actualizaCli = await InsertarActualizarCliente(clienteCorta);
                                        //Entra al if si se actualiza cliente
                                        if (actualizaCli)
                                        {
                                            //Creación del objeto "movimiento"
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
                                                IdDosificacion = eDosificacionCompleja.IdDosificacion,
                                                NroMovimiento = eDosificacionCompleja.NroFinalFactura,
                                                CodigoControl = CodigoControl.generateControlCode(eDosificacionCompleja.NroAutorizacion, eDosificacionCompleja.NroFinalFactura.ToString(), "8934674", DateTime.Now.ToString("yyyyMMdd"), VariablesGlobales.Total.ToString("0.00"), eDosificacionCompleja.LlaveDosificacion),
                                                RazonSocial = razon,
                                                NitCi = nit
                                            };
                                            //Se registra el movimiento con los datos actuales
                                            bool res = await Insertar_Movimiento_ConFactura(eMovimientoCompleja);
                                            //Entra al if si se registra la venta
                                            if (res)
                                            {
                                                //Obtener el movimiento recien insertado para agarrar su ID y adjuntarlo a DetalleMovimiento
                                                int idMovi = await Obtener_Ultimo_IdMovimiento();
                                                //Recorrer los productos registrados para la venta
                                                var indice = 1;
                                                var itt = _viewModel.Productos;
                                                foreach (var item in itt)
                                                {
                                                    //Creación del objeto "detalle movimiento"
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
                                                    //Se registra el detalle movimiento con los datos actuales
                                                    bool ress = await InsertarDetalleMovimiento(eDetalleMovimientoCompleja);
                                                    //Entra al if si se registra el detalle venta
                                                    if (ress)
                                                    {
                                                        //Entrar al if si es el último producto registrado para la venta
                                                        if (itt.Count == indice)
                                                        {
                                                            //Instancia de las clases para la generacion de la factura y el posterior envio del correo
                                                            generarFactura = new GenerarFactura();
                                                            envioCorreo = new EnvioCorreo();
                                                            //Se genera la factura y se declara el correo del receptor
                                                            byte[] pdf = generarFactura.GenerarPdf(itt, eMovimientoCompleja, eDetalleMovimientoCompleja, eDosificacionCompleja);
                                                            string correo = clienteCompleja.CorreoElectronico;
                                                            await DisplayAlert("Venta", "Venta Registrada con exito.", "Ok");
                                                            envioCorreo.EnviarCorreo("AquacorpSanAntonioSRL@gmail.com", correo, pdf);
                                                        }
                                                    }
                                                    //Entra al else si no se registró el detalle venta
                                                    else
                                                    {
                                                        await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                                                        // new Exception();
                                                    }
                                                    indice++;
                                                }
                                            }
                                            //Entra al else si no se registra la venta
                                            else
                                            {
                                                await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                                            }
                                        }
                                        //Entra al else si no se actualizó el cliente
                                        else
                                        {
                                            await DisplayAlert("Cliente", "Problema al actualizar datos de cliente.", "Ok");
                                        }
                                    }
                                    //Entra al else si se requiere modificar
                                    else
                                    {
                                        //Se incrementa el nroFinalFactura
                                        eDosificacionCompleja.NroFinalFactura++;
                                        //Crear un objeto basado en la clase cliente
                                        string nuevoRazonSocial = await DisplayPromptAsync("Nueva Razon Social", "");
                                        string nuevoNit = await DisplayPromptAsync("Nuevo Nit o Ci", "");
                                        EClienteActualizarCorta clienteCorta = new EClienteActualizarCorta()
                                        {
                                            FotoUbicacion = clienteCompleja.FotoUbicacion,
                                            RazonSocial = nuevoRazonSocial,
                                            NitCi = nuevoNit,
                                            IdCliente = clienteCompleja.IdCliente
                                        };
                                        //Actualizar los datos de cliente
                                        bool actualizaCli = await InsertarActualizarCliente(clienteCorta);
                                        //Entra al if si se actualiza cliente
                                        if (actualizaCli)
                                        {
                                            //Creación del objeto "movimiento"
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
                                                IdDosificacion = eDosificacionCompleja.IdDosificacion,
                                                NroMovimiento = eDosificacionCompleja.NroFinalFactura,
                                                CodigoControl = CodigoControl.generateControlCode(eDosificacionCompleja.NroAutorizacion, eDosificacionCompleja.NroFinalFactura.ToString(), "8934674", DateTime.Now.ToString("yyyyMMdd"), VariablesGlobales.Total.ToString("0.00"), eDosificacionCompleja.LlaveDosificacion),
                                                RazonSocial = nuevoRazonSocial,
                                                NitCi = nuevoNit
                                            };
                                            //Se registra el movimiento con los datos actuales
                                            bool res = await Insertar_Movimiento_ConFactura(eMovimientoCompleja);
                                            //Entra al if si se registra la venta
                                            if (res)
                                            {
                                                //Obtener el movimiento recien insertado para agarrar su ID y adjuntarlo a DetalleMovimiento
                                                int idMovi = await Obtener_Ultimo_IdMovimiento();
                                                //Recorrer los productos registrados para la venta
                                                var indice = 1;
                                                var itt = _viewModel.Productos;
                                                foreach (var item in itt)
                                                {
                                                    //Creación del objeto "detalle movimiento"
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
                                                    //Se registra el detalle movimiento con los datos actuales
                                                    bool ress = await InsertarDetalleMovimiento(eDetalleMovimientoCompleja);
                                                    //Entra al if si se registra el detalle venta
                                                    if (ress)
                                                    {
                                                        if (itt.Count == indice)
                                                        {
                                                            //Instancia de la clase EDosificacionCompleja
                                                            generarFactura = new GenerarFactura();
                                                            envioCorreo = new EnvioCorreo();
                                                            //Se genera la factura y se declara el correo del receptor
                                                            byte[] pdf = generarFactura.GenerarPdf(itt, eMovimientoCompleja, eDetalleMovimientoCompleja, eDosificacionCompleja);
                                                            string correo = clienteCompleja.CorreoElectronico;
                                                            //Mostrar un mensaje que ya se realizó la venta
                                                            await DisplayAlert("Venta", "Venta Registrada con exito.", "Ok");
                                                            //Enviar el correo
                                                            envioCorreo.EnviarCorreo("AquacorpSanAntonioSRL@gmail.com", correo, pdf);
                                                        }
                                                    }
                                                    //Entra al else si no se registra la venta
                                                    else
                                                    {
                                                        await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                                                        // new Exception();
                                                    }
                                                    indice++;
                                                }
                                            }
                                            //Entra al if si no se registra la venta
                                            else
                                            {
                                                await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                                            }
                                        }
                                        //Entra al else si no se actualizó el cliente
                                        else
                                        {
                                            await DisplayAlert("Cliente", "Problema al actualizar datos de cliente.", "Ok");
                                        }
                                    }
                                }
                                //Entra al else si no hay dosificacion o si su fecha limite ya caducó
                                else
                                {
                                    await DisplayAlert("Venta No Realizada", "No Existe Una Dosificación Vigente", "Ok");
                                }
                            }
                            //Entra al else si no requiere factura
                            else
                            {
                                //Creación del objeto "movimiento"
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
                                //Se registra el movimiento con los datos actuales y sin factura
                                bool res = await Insertar_Movimiento_SinFactura(eMovimientoCompleja);
                                //Entra al if si se registró el movimiento
                                if (res)
                                {
                                    //Obtener el movimiento recien insertado para agarrar su ID y adjuntarlo a DetalleMovimiento
                                    int idMovi = await Obtener_Ultimo_IdMovimiento();
                                    //Recorrer los productos registrados para la venta
                                    var itt = _viewModel.Productos;
                                    foreach (var item in itt)
                                    {
                                        //Creación del objeto "detalle movimiento"
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
                                        //Se registra el detalle movimiento con los datos actuales
                                        bool ress = await InsertarDetalleMovimiento(eDetalleMovimientoCompleja);
                                        //Entra al if si se registra el detalle venta
                                        if (ress)
                                        {
                                            await DisplayAlert("Venta", "Venta Registrada con exito.", "Ok");
                                        }
                                        //Entra al else si no se registra el detalle venta
                                        else
                                        {
                                            await DisplayAlert("Venta", "Problema al registrar venta.", "Ok");
                                        }
                                    }
                                }
                                //Entra al else si hubo problemas al registrar la venta
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
                        //Lanzar mensaje si no se seleccionó ni un producto
                        else
                        {
                            await DisplayAlert("Productos", "Seleccione un producto para venta.", "Ok");
                        }
                    }
                    //Lanzar mensaje si no se seleccionó el cliente
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