using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xamarin.Forms;
using Plugin.Connectivity;
using AppDistribuidor.ViewModels;
using Xamarin.Forms.Xaml;
using System.IO;
using Android.Graphics;
using Plugin.LocalNotification;
using AppDistribuidor.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Plugin.Toast;
using System.Text.RegularExpressions;

namespace AppDistribuidor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        string nombrecel = "";
        decimal latit = 0;
        decimal lonit = 0;
        byte nume = 0;


        public AboutPage()
        {
            InitializeComponent();

            this.BindingContext = new FotoViewModel();
            Localizar();
            // VariablesGlobales.stream = GetStreamFromUrl("https://i.ibb.co/njxyvPL/descarga.png");
            VariablesGlobales.Bandera = 0;



            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;

            //if (Device.RuntimePlatform == Device.Android)
            //{
            //    //MessagingCenter.Subscribe<LocationMessage>(this, "Location", message =>
            //    //{


            //    //    Device.BeginInvokeOnMainThread(async () =>
            //    //    {
            //    //        latit = (decimal)message.Latitude;
            //    //        lonit = (decimal)message.Longitude;
            //    //        nume++;
            //    //        locationLabel.Text += $"{Environment.NewLine}==" + nume + "== " + DateTime.Now.ToString() + "==";
            //    //        Console.WriteLine($"-----   ENTRA AL METODO QUE REPITE VARIAS VECES   -----");
            //    //        // Task.Run(async () => await LlenarBdd(nombrecel, latit, lonit, DateTime.Now)).Wait();
            //    //        if (nume == 12)
            //    //        {
            //    //            if (CheckConexion())
            //    //            {
            //    //                bool bande = await LlenarBdd();
            //    //                if (bande)
            //    //                {
            //    //                    locationLabel.Text += $"{Environment.NewLine}========GRABOOO========";
            //    //                    Console.WriteLine($"-----    GRABOOO    -----");

            //    //                }
            //    //                else
            //    //                {
            //    //                    locationLabel.Text += $"{Environment.NewLine}========NOOOOOOO========";
            //    //                    Console.WriteLine($"-----    NOOOOOOO    -----");
            //    //                }
            //    //                //bool ban = Task.Run(() => LlenarBdd2(nombrecel, latit, lonit, DateTime.Now).Get)
            //    //            }
            //    //            nume = 0;
            //    //        }
            //    //    });
            //    //});



            //    //MessagingCenter.Subscribe<StopServiceMessage>(this, "ServicioCancelado", message =>
            //    //{
            //    //    Device.BeginInvokeOnMainThread(() =>
            //    //    {
            //    //        locationLabel.Text = "Servicio de San Antonio Finalizado!";
            //    //    });
            //    //});

            //    //MessagingCenter.Subscribe<LocationErrorMessage>(this, "LocationError", message =>
            //    //{
            //    //    Device.BeginInvokeOnMainThread(() =>
            //    //    {
            //    //        locationLabel.Text = "Hay un error obteniendo el servicio!";
            //    //    });
            //    //});

            //    //if (Preferences.Get("LocationServiceRunning", false) == true)
            //    //{
            //    //    StartService();
            //    //}
            //}
        }
        private static Stream GetStreamFromUrl(string url)
        {
            byte[] imageData = null;

            using (var wc = new System.Net.WebClient())
                imageData = wc.DownloadData(url);

            return new MemoryStream(imageData);
        }
        public bool CheckConexion()
        {
            Console.WriteLine($"-----   ENTRA VERIFICAR CONEXION A INTERNET  -----");
            bool ban = false;
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    ban = true;
                }
                else
                {
                    CrossToastPopUp.Current.ShowToastMessage("No existe una conexion a Internet. ");
                    //  DisplayAlert("Conexión a Internet", "No existe una conexion a Internet. \n Por favor Conectese a internet eh intente de nuevo.", "OK");
                    ban = false;
                }
            }
            catch (Exception ex)
            {
                CrossToastPopUp.Current.ShowToastMessage("Ocurrio un problema al verificar conexion a internet. ");
                // DisplayAlert("Error", "Ocurrio un problema al verificar conexion a internet.\n " + ex.Message, "OK");

            }
            Console.WriteLine($"-----  SALE DE VERIFICAR CONEXION A INTERNET  -----");
            return ban;

        }

        //POST INSERTAR ACTUALIZAR
        public static async Task<bool> GetAccessAsync(string usuario, string contra)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/InsertarUbicacionDistribuidor").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (responseContent == "true") return true;
            else return false;

        }

        public static async Task<bool> Insertar_UbicacionDistribuidor(EUbicacion eEUbicacion)
        {
            Console.WriteLine($"----- ENTRA A INSERTAR UBICACION A BASE DE DATOS  -----");
            using (HttpClient cliente = new HttpClient())
            {
                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                //POST Request
                string requestUrl = "http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/InsertarUbicacionDistribuidor";


                string jsonString = JsonConvert.SerializeObject(eEUbicacion, microsoftDateFormatSettings);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = cliente.PostAsync(requestUrl, request).Result;
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (result == "true") return true;
                else return false;
            }


        }

        public async Task<bool> Verificar_Cliente_Correo(string correo)
        {
            var client = new HttpClient();
            Task<string> response =  client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Verificar_Cliente_Correo" + "/" + correo);
            
            DoIndependentWork();
            string contents = await response;

            if (contents == "true") return true;
            else return false;


        }

        public void DoIndependentWork()
        {
            Console.WriteLine("Working...");
        }

        public bool InsertarCliente(EClienteCompleja eECliente)
        {

            using (HttpClient cliente = new HttpClient())
            {
                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                //POST Request
                string requestUrl = "http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/InsertarCliente";


                string jsonString = JsonConvert.SerializeObject(eECliente, microsoftDateFormatSettings);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = cliente.PostAsync(requestUrl, request).Result;
                var result = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                string resp = Convert.ToString(result);
                if (resp == "true") return true;
                else return false;
            }


        }



        //public async Task<bool> LlenarBdd()
        //{
        //    bool ban = false;
        //    int idUsu = VariablesGlobales.IdUsuario;
        //    // SWNegocio.SWNegocioAquacorpClient cliente = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);

        //    try
        //    {
        //        //SWNegocio.EUbicacionDistribuidorCompleja eUbicacionCompleja = new SWNegocio.EUbicacionDistribuidorCompleja()
        //        //{
        //        //    IdUsuario = idUsu,
        //        //    NombreDispositivo = nombrecel,
        //        //    Latitud = latit,
        //        //    Longitud = lonit,
        //        //    Fecha = DateTime.Now
        //        //};
        //        EUbicacion eUbicacionCompleja = new EUbicacion()
        //        {
        //            IdUsuario = idUsu,
        //            NombreDispositivo = nombrecel,
        //            Latitud = latit,
        //            Longitud = lonit,
        //            Fecha = DateTime.Now
        //        };


        //        ban = Task.Run(() => Insertar_UbicacionDistribuidor(eUbicacionCompleja)).GetAwaiter().GetResult();
        //        // ban = Task.Run(() => cliente.Insertar_UbicacionDistribuidor(eUbicacionCompleja)).GetAwaiter().GetResult();

        //        locationLabel.Text += $"{Environment.NewLine}=== Datos Registrados en BDD ===";
        //        await Task.Delay(500);
        //        //await cliente.CloseAsync();

        //    }
        //    catch (CommunicationException et)
        //    {
        //        //cliente.Abort();
        //        locationLabel.Text += $"{Environment.NewLine}====={et.Message}";
        //    }
        //    catch (SqlException ex) when (ex.Number == -2)
        //    {
        //        Console.WriteLine("Timeout occurred");
        //        locationLabel.Text += $"{Environment.NewLine}====={ex.Message}";
        //    }
        //    //finally
        //    //{
        //    //    await cliente.CloseAsync();
        //    //    cliente.Abort();


        //    //}
        //    return ban;
        //}

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine($"-----   ENTRA A PEDIR PERMISO PARA UBICACION   -----");
            var permission = await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.LocationAlways>();

            if (permission == Xamarin.Essentials.PermissionStatus.Denied)
            {
                // TODO Let the user know they need to accept
                return;
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                if (CrossGeolocator.Current.IsListening)
                {
                    await CrossGeolocator.Current.StopListeningAsync();
                    CrossGeolocator.Current.PositionChanged -= Current_PositionChanged;
                    return;
                }
                await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(1), 10, false, new Plugin.Geolocator.Abstractions.ListenerSettings
                {
                    ActivityType = Plugin.Geolocator.Abstractions.ActivityType.AutomotiveNavigation,
                    AllowBackgroundUpdates = true,
                    DeferLocationUpdates = false,
                    DeferralDistanceMeters = 10,
                    DeferralTime = TimeSpan.FromSeconds(5),
                    ListenForSignificantChanges = true,
                    PauseLocationUpdatesAutomatically = true
                });

                CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                if (Preferences.Get("LocationServiceRunning", false) == false)
                {
                    Console.WriteLine($"-----   SERVICIO DE LOCALIZACION EMPIEZA   -----");
                   // StartService();
                }
                else
                {
                  //  StopService();
                }
            }
        }
        public async void EmpezarTodo()
        {
            var permission = await Permissions.RequestAsync<Permissions.LocationAlways>();

            if (permission == PermissionStatus.Denied)
            {
                // TODO Let the user know they need to accept
                return;
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                if (CrossGeolocator.Current.IsListening)
                {
                    await CrossGeolocator.Current.StopListeningAsync();
                    CrossGeolocator.Current.PositionChanged -= Current_PositionChanged;
                    return;
                }
                await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(1), 10, false, new Plugin.Geolocator.Abstractions.ListenerSettings
                {
                    ActivityType = Plugin.Geolocator.Abstractions.ActivityType.AutomotiveNavigation,
                    AllowBackgroundUpdates = true,
                    DeferLocationUpdates = false,
                    DeferralDistanceMeters = 10,
                    DeferralTime = TimeSpan.FromSeconds(5),
                    ListenForSignificantChanges = true,
                    PauseLocationUpdatesAutomatically = true
                });

                CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                if (Preferences.Get("LocationServiceRunning", false) == false)
                {
                  //  StartService();
                }
                else
                {
                   // StopService();
                }
            }
        }
        //private void StartService()
        //{
        //    var startServiceMessage = new StartServiceMessage();
        //    MessagingCenter.Send(startServiceMessage, "ServicioInicio");
        //    Preferences.Set("LocationServiceRunning", true);
        //    locationLabel.Text = "Geolocalizacion Inicio";
        //    BtnInicio.Text = "Stop";
        //    BtnInicio.BackgroundColor = Xamarin.Forms.Color.FromRgb(43, 149, 219);
        //    var modelo = DeviceInfo.Model;
        //    var marca = DeviceInfo.Manufacturer;
        //    var nombre = DeviceInfo.Name;
        //    var version = DeviceInfo.VersionString;
        //    var plataforma = DeviceInfo.Platform;
        //    var idioma = DeviceInfo.Idiom;
        //    var tipoDispositivo = DeviceInfo.DeviceType;

        //    //locationLabel.Text += String.Format("Modelo:{0}" +
        //    //                              "\nMarca:{1}" +
        //    //                              "\nNombre:{2}" +
        //    //                             "\nVersion:{3}" +
        //    //                              "\nPlataforma:{4}" +
        //    //                              "\nIdioma:{5}" +
        //    //                              "\nTipo Dispositivo:{6}", modelo, marca, nombre, version, plataforma, idioma, tipoDispositivo);
        //    nombrecel = String.Format("Modelo:{0}" +
        //                                  "Marca:{1}" +
        //                                  "Nombre:{2}" +
        //                                 "Version:{3}" +
        //                                  "Plataforma:{4}" +
        //                                  "Idioma:{5}" +
        //                                  "Tipo Dispositivo:{6}", modelo, marca, nombre, version, plataforma, idioma, tipoDispositivo);
        //    locationLabel.Text += $"{Environment.NewLine}";

        //}

        //private void StopService()
        //{
        //    var stopServiceMessage = new StopServiceMessage();
        //    MessagingCenter.Send(stopServiceMessage, "ServiceStopped");
        //    Preferences.Set("LocationServiceRunning", false);
        //    BtnInicio.Text = "Iniciar";
        //    BtnInicio.BackgroundColor = Xamarin.Forms.Color.FromRgb(43, 189, 47);
        //}

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            //locationLabel.Text += $"{e.Position.Latitude}, {e.Position.Longitude}, {e.Position.Timestamp.TimeOfDay}{Environment.NewLine}";
            //LlenarBdd(nombrecel, (decimal)e.Position.Latitude, (decimal)e.Position.Longitude, DateTime.Now);
            Console.WriteLine($"{e.Position.Latitude}, {e.Position.Longitude}, {e.Position.Timestamp.TimeOfDay}");
        }

        private void BtnConectar_Clicked(object sender, EventArgs e)
        {


        }




        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
        public static Stream GetStreamFromImageSource(ImageSource source)
        {
            StreamImageSource streamImageSource = (StreamImageSource)source;
            System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
            Task<Stream> task = streamImageSource.Stream(cancellationToken);
            Stream stream = task.Result;
            return stream;
        }


        public byte[] ResizeImage(byte[] imageData, float width, float height)
        {
            // Load the bitmap 
            BitmapFactory.Options options = new BitmapFactory.Options();// Create object of bitmapfactory's option method for further option use
            options.InPurgeable = true; // inPurgeable is used to free up memory while required
            Android.Graphics.Bitmap originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length, options);

            float newHeight = 0;
            float newWidth = 0;

            var originalHeight = originalImage.Height;
            var originalWidth = originalImage.Width;

            if (originalHeight > originalWidth)
            {
                newHeight = height;
                float ratio = originalHeight / height;
                newWidth = originalWidth / ratio;
            }
            else
            {
                newWidth = width;
                float ratio = originalWidth / width;
                newHeight = originalHeight / ratio;
            }

            Android.Graphics.Bitmap resizedImage = Android.Graphics.Bitmap.CreateScaledBitmap(originalImage, (int)newWidth, (int)newHeight, true);

            originalImage.Recycle();

            using (MemoryStream ms = new MemoryStream())
            {
                resizedImage.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 100, ms);

                resizedImage.Recycle();

                return ms.ToArray();
            }
        }


        private async void Localizar()
        {
            var locator = CrossGeolocator.Current; //acceso a la api
            locator.DesiredAccuracy = 50; //presicion en metros
            if (locator.IsGeolocationAvailable)//servicio existente en el dispositivo        
            { 
            if(locator.IsGeolocationEnabled)//GPS activado en el dispositivo
                {
                    if(!locator.IsListening)//comprueba si el dispositivo escucha al servicio
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5); //incia de la escucha
                    }
                    locator.PositionChanged += (cambio, args) =>
                    {
                        var loc = args.Position;
                        latit = decimal.Parse(loc.Latitude.ToString()); 
                        lonit = decimal.Parse(loc.Longitude.ToString());
                    };
                }          
            }
        }



        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (CheckConexion())
                {
                    if (Validar())
                    {


                        if (latit == 0)
                        {
                            // TODO Let the user know they need to accept
                            Localizar();
                        }
                        else
                        {

                            decimal nulati = latit;
                            decimal nuLongi = lonit;



                            Stream streamIma;
                            byte[] byteIma;
                            byte[] nuevo;

                            if (VariablesGlobales.Bandera == 0)
                            {
                                streamIma = VariablesGlobales.stream;
                                nuevo = ReadFully(streamIma);
                            }
                            else
                            {
                                streamIma = VariablesGlobales.stream;
                                byteIma = ReadFully(streamIma);
                                nuevo = ResizeImage(byteIma, 120, 120);
                            }


                            string apellido = "";
                            if (TxtSegundoApellido.Text.Trim().Length < 1)
                            {
                                apellido = "";
                            }
                            else
                            {
                                apellido = TxtSegundoApellido.Text.Trim().ToUpper();
                            }


                            EClienteCompleja eClienteCompleja = new EClienteCompleja()
                            {
                                Estado = "HA",
                                FechaModificacion = DateTime.Now,
                                FechaRegistro = DateTime.Now,
                                IdPersona = 1,
                                Nombres = TxtNombres.Text.Trim().ToUpper(),
                                PrimerApellido = TxtPrimerApellido.Text.Trim().ToUpper(),
                                SegundoApellido = apellido,
                                Telefono = TxtTelefono.Text.Trim(),
                                Cont = 1,
                                CorreoElectronico = TxtCorreo.Text.Trim().ToUpper(),
                                FotoUbicacion = nuevo,
                                IdCliente = 1,
                                RazonSocial = TxtRazon.Text.Trim().ToUpper(),
                                NitCi = TxtNit.Text.Trim(),
                                Direccion = TxtDireccion.Text.Trim().ToUpper(),
                                Latitud = nulati,
                                Longitud = nuLongi

                            };

                            bool res = InsertarCliente(eClienteCompleja);



                            if (VariablesGlobales.TipoRegistroCliente == 1)
                            {
                                if (res)
                                {

                                    CrossToastPopUp.Current.ShowToastMessage("Cliente registrado.");
                                    VariablesGlobales.NombreClienteRegistrado = TxtNombres.Text.ToUpper() + " " + TxtPrimerApellido.Text.ToUpper() + " " + TxtSegundoApellido.Text.ToUpper();
                                    Limpiar();
                                    Navigation.PopAsync();
                                }
                                else
                                {
                                    CrossToastPopUp.Current.ShowToastMessage("Cliente NO registrado.");
                                    CrossToastPopUp.Current.ShowToastMessage("Intente de nuevo.");
                                }
                            }
                            else
                            {
                                if (res)
                                {
                                    Limpiar();
                                    DisplayAlert("Cliente", "El nuevo cliente fue registrado exitosamente.", "Ok");
                                }
                                else
                                {
                                    DisplayAlert("Cliente", "El nuevo cliente no pudo ser registrado.", "Ok");
                                }
                            }
                        }
                    }
                }
                

            }
            catch (Exception ex)
            {

                DisplayAlert("Cliente", "Ocurrio un error al registrar cliente." + ex.Message, "Ok");
            }
        }

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(TxtNombres.Text.Trim()))
            {
                CrossToastPopUp.Current.ShowToastMessage("Nombres es obligatorio.");
                return false;

            }
            else
            {
                if (TxtNombres.Text.Trim().Length < 3)
                {
                    CrossToastPopUp.Current.ShowToastMessage("Nombres incorrecto.");
                    return false;

                }
                else
                {
                    if (string.IsNullOrWhiteSpace(TxtPrimerApellido.Text.Trim()))
                    {
                        CrossToastPopUp.Current.ShowToastMessage("Primer Apellido es obligatorio. ");
                        return false;
                    }
                    else
                    {
                        if (TxtPrimerApellido.Text.Trim().Length < 3)
                        {
                            CrossToastPopUp.Current.ShowToastMessage("Primer Apellido incorrecto");
                            return false;
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(TxtDireccion.Text.Trim()))
                            {
                                CrossToastPopUp.Current.ShowToastMessage("Direccion es obligatorio. ");
                                return false;
                            }
                            else
                            {
                                if (TxtDireccion.Text.Trim().Length < 10 && TxtDireccion.Text.Trim().Length > 250)
                                {
                                    CrossToastPopUp.Current.ShowToastMessage("Direccion incorrecto");
                                    return false;
                                }
                                else
                                {
                                    if (string.IsNullOrWhiteSpace(TxtTelefono.Text.Trim()))
                                    {
                                        CrossToastPopUp.Current.ShowToastMessage("Telefono es obligatorio. ");
                                        return false;
                                    }
                                    else
                                    {
                                        if (TxtTelefono.Text.Trim().Length < 7 || TxtTelefono.Text.Trim().Length > 8)
                                        {
                                            CrossToastPopUp.Current.ShowToastMessage("Telefono incorrecto. ");
                                            return false;
                                        }
                                        else
                                        {
                                            if (string.IsNullOrWhiteSpace(TxtCorreo.Text.Trim()))
                                            {
                                                CrossToastPopUp.Current.ShowToastMessage("Correo es obligatorio. ");
                                                return false;
                                            }
                                            else
                                            {
                                                if (!IsValidEmail(TxtCorreo.Text.Trim()))
                                                {
                                                    CrossToastPopUp.Current.ShowToastMessage("Correo invalido. ");
                                                    return false;
                                                }
                                                else
                                                {
                                                    bool res = Task.Run(() => Verificar_Cliente_Correo(TxtCorreo.Text.Trim().ToUpper())).GetAwaiter().GetResult();
                                                    if (res)
                                                    {
                                                        CrossToastPopUp.Current.ShowToastMessage("Correo ya registrado.");
                                                        return false;
                                                    }
                                                    else
                                                    {
                                                            return true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        //public static async Task<List<ECategoriaCliente>> Obtener_CategoriaCliente()
        //{
        //    var client = new HttpClient();
        //    var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_CategoriaCliente");
        //    string resp = Convert.ToString(responseString);
        //    var obj = JsonConvert.DeserializeObject<object>(resp);
        //    string data = Convert.ToString(obj);
        //    List<ECategoriaCliente> eUsuarioCompleja = new List<ECategoriaCliente>();
        //    eUsuarioCompleja = JsonConvert.DeserializeObject<List<ECategoriaCliente>>(data);
        //    return eUsuarioCompleja;

        //}
        //public void LlenarCategorias()
        //{
        //    try
        //    {
        //        //SWNegocio.SWNegocioAquacorpClient cliente = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);
        //        List<ECategoriaCliente> eCategoriaCliente = Task.Run(() => Obtener_CategoriaCliente()).GetAwaiter().GetResult();
        //        DdlstCategoria.ItemsSource = eCategoriaCliente;
        //        DdlstCategoria.ItemDisplayBinding = new Binding("NombreCategoriaCliente");
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}
        //public static async Task<List<EZona>> Obtener_Zona()
        //{
        //    var client = new HttpClient();
        //    var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Zona");
        //    string resp = Convert.ToString(responseString);
        //    var obj = JsonConvert.DeserializeObject<object>(resp);
        //    string data = Convert.ToString(obj);
        //    List<EZona> eUsuarioCompleja = new List<EZona>();
        //    eUsuarioCompleja = JsonConvert.DeserializeObject<List<EZona>>(data);
        //    return eUsuarioCompleja;

        //}
        //public void LlenarZonas()
        //{
        //    try
        //    {
        //        SWNegocio.SWNegocioAquacorpClient cliente = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);
        //        List<EZona> eZona = Task.Run(() => Obtener_Zona()).GetAwaiter().GetResult();
        //        DdlstZona.ItemsSource = eZona;
        //        DdlstZona.ItemDisplayBinding = new Binding("NombreZona");
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}




        public void Limpiar()
        {
            TxtNombres.Text = string.Empty;
            TxtPrimerApellido.Text = string.Empty;
            TxtSegundoApellido.Text = string.Empty;
            TxtDireccion.Text = string.Empty;
            TxtTelefono.Text = string.Empty;
            TxtCorreo.Text = string.Empty;
            TxtRazon.Text = string.Empty;
            TxtNit.Text = string.Empty;

            fotito.Source = ImageSource.FromUri(new Uri("https://i.ibb.co/qChmypq/descarga.png"));
            VariablesGlobales.stream = GetStreamFromUrl("https://i.ibb.co/qChmypq/descarga.png");
            VariablesGlobales.Bandera = 0;
        }


        public void NotificarPedido()
        {
            Random myObject = new Random();
            int ranNum = myObject.Next(1000, 9999);
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Tiene un pedido nuevo",
                Title = "Pedido Asignado",
                ReturningData = "Pedido Dato",
                NotificationId = ranNum
            };

            LocalNotificationCenter.Current.Show(notification);

        }




        private void BtnNotificacion_Clicked(object sender, EventArgs e)
        {
            //  CrossLocalNotifications.Current.Show("Prueba de Notificacion","Tiene un pedido nuevo");
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Tiene un pedido nuevo",
                Title = "Prueba de Notificacion",
                ReturningData = "Pedido Dato",
                NotificationId = 1337


            };



            LocalNotificationCenter.Current.Show(notification);
        }
    }
}