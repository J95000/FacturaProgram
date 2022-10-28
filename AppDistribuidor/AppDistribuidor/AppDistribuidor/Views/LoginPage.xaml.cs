using AppDistribuidor.ViewModels;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SWNegocio;
using System.Net.Http;
using Newtonsoft.Json;
using AppDistribuidor.Models;

namespace AppDistribuidor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }


        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (CheckConexion())
            {
                LoginMetodo();
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
        //public static async Task<bool> GetAccessAsync(string usuario, string contra)
        //{
        //    Console.WriteLine($"-----   ENTRA AL METODO GetAccessAsync   -----");
        //    var client = new HttpClient();
        //    //var response = await client.GetAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Acceso_Ci_Contrasena" + "/" + usuario + "/" + contra).ConfigureAwait(false);
        //    //response.EnsureSuccessStatusCode();
        //    //var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        //    var response = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Acceso_Ci_Contrasena" + "/" + usuario + "/" + contra);
        //    string resp = Convert.ToString(response);
        //    var obj = JsonConvert.DeserializeObject<object>(resp);
        //    string data = Convert.ToString(obj);

        //    Console.WriteLine($"-----   SALE AL METODO GetAccessAsync   -----" + data);
        //    if (data == "true") return true;
        //    else return false;

        //}

        //public static async Task<bool> GetAccessAsync(string usuario, string contra)
        //{
        //    var client = new HttpClient();
        //    var response = await client.GetAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Acceso_Ci_Contrasena" + "/" + usuario + "/" + contra).ConfigureAwait(false);
        //    response.EnsureSuccessStatusCode();
        //    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        //    if (responseContent == "true") return true;
        //    else return false;

        //}


        public async Task<bool> GetAccessAsync(string usuario, string contra)
        {
            var client = new HttpClient();
            Task<string> response = client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Acceso_Ci_Contrasena" + "/" + usuario + "/" + contra);

            DoIndependentWork();
            string contents = await response;

            if (contents == "true") return true;
            else return false;

        }
        public void DoIndependentWork()
        {
            Console.WriteLine("Working...");
        }
        public static async Task<EUsuario> GetUsuarioAsync(string usuario)
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Usuario_Empleado_Ci" + "/" + usuario);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            EUsuario eUsuarioCompleja = new EUsuario();
            eUsuarioCompleja = JsonConvert.DeserializeObject<EUsuario>(data);
            return eUsuarioCompleja;

        }
        public static async Task<EEmpleadoCortaCompleja> GetEmpleadoAsync(string IdEmpleado)
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Empleado_Id_Empleado" + "/" + IdEmpleado);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            EEmpleadoCortaCompleja eUsuarioCompleja = new EEmpleadoCortaCompleja();
            eUsuarioCompleja = JsonConvert.DeserializeObject<EEmpleadoCortaCompleja>(data);
            return eUsuarioCompleja;

        }


        private static EUsuario ObtenerUsuario(string nombreUsuario)
        {
            Console.WriteLine($"-----ENTRA A ObtenerUsuario()-----");
            EUsuario eUsuarioCompleja = new EUsuario();

            eUsuarioCompleja = Task.Run(() => GetUsuarioAsync(nombreUsuario.Trim())).GetAwaiter().GetResult();
            Task.Delay(100);
            Console.WriteLine($"SE OBTUVO---- USUARIO : " + nombreUsuario + "  NOMBRE_TIPO_USUARIO : " + eUsuarioCompleja.NombreTipoUsuario + "  ID_USUARIO : " + eUsuarioCompleja.IdUsuario);

            Task.WaitAll();
            Console.WriteLine($"-----SALE A ObtenerUsuario()-----");
            return eUsuarioCompleja;
        }
      
        private static EEmpleadoCortaCompleja ObtenerEmpleado(int idUsuario)
        {
            Console.WriteLine($"-----ENTRA A ObtenerEmpleado()-----");
            EEmpleadoCortaCompleja eEmpleadoCompleja = new EEmpleadoCortaCompleja();

            eEmpleadoCompleja = Task.Run(() => GetEmpleadoAsync(idUsuario.ToString())).GetAwaiter().GetResult();
            Task.Delay(100);
            Console.WriteLine($"SE OBTUVO ---- ID_USUARIO : " + idUsuario + "  ID_CARGO : " + eEmpleadoCompleja.IdCargo + "  NOMBRE_CARGO : " + eEmpleadoCompleja.NombreCargo + "  ID_EMPLEADO : " + eEmpleadoCompleja.IdEmpleado + "  NOMBRE_EMPLEADO : " + eEmpleadoCompleja.NombreCompleto);

            Task.WaitAll();
            Console.WriteLine($"-----SALE A ObtenerEmpleado()-----");
            return eEmpleadoCompleja;
        }


        public async void LoginMetodo()
        {
             try
            {
                Console.WriteLine($"-----   ENTRA AL METODO LOGIN   -----");
                LblMensaje1.IsVisible = false;
                LblMensaje2.IsVisible = false;
                loader.IsRunning = true;
                loader.IsVisible = true;
                BtnLogin.IsEnabled = false;
                await Task.Delay(500);
                Console.WriteLine($"-----   OBTIENE ACCESO  -----");
                bool res = Task.Run(() => GetAccessAsync(TxtUsuario.Text.Trim().ToUpper(), TxtContrasena.Text.Trim())).GetAwaiter().GetResult();
                await Task.Delay(100);// bool res = Task.Run(() => sWNegocioAquacorpClient.Acceso_Ci_Contrasena_async(TxtUsuario.Text.Trim().ToUpper(), TxtContrasena.Text.Trim())).GetAwaiter().GetResult();
                Console.WriteLine($"-----  YA OBTUVO  ACCESO  -----");

                if (res)
                {
                    Console.WriteLine($"-----   OBTIENE USUARIO  -----");
                   // EUsuario eUsuarioCompleja = Task.Run(() => GetUsuarioAsync(TxtUsuario.Text.Trim())).GetAwaiter().GetResult();
                    

                     Console.WriteLine($"-----   OBTIENE EMPLEADO  -----");
                    // EEmpleadoCortaCompleja eEmpleadoCompleja = Task.Run(() => GetEmpleadoAsync(eUsuarioCompleja.IdUsuario.ToString())).GetAwaiter().GetResult();
                    EUsuario eUsuarioCompleja = ObtenerUsuario(TxtUsuario.Text);
                    EEmpleadoCortaCompleja eEmpleadoCompleja = ObtenerEmpleado(eUsuarioCompleja.IdUsuario);



                    Console.WriteLine($"-----   ENTRA A CARGO  -----");
                    string cargo = eEmpleadoCompleja.NombreCargo;
                    if (cargo == "DISTRIBUCION" || cargo == "GERENTE GENERAL")
                    {
                        VariablesGlobales.IdUsuario = eUsuarioCompleja.IdUsuario;
                        VariablesGlobales.NombreUsuario = eEmpleadoCompleja.NombreCompleto;
                        VariablesGlobales.Contrasena = TxtContrasena.Text.Trim().ToUpper();
                        if (TxtUsuario.Text.Trim() == TxtContrasena.Text.Trim())
                        {
                            await Task.Delay(500);
                            Application.Current.MainPage = new PasswordChangePage();
                        }
                        else
                        {
                            Console.WriteLine($"-----   ENTRA A NAVEGACION HACIA APPSHELL  -----");
                            await Task.Delay(50);
                            Application.Current.MainPage = new AppShell();
                        }



                    }
                    else
                    {
                        TxtUsuario.Text = "";
                        TxtContrasena.Text = "";
                        TxtUsuario.Focus();
                        await DisplayAlert("Usuario incorrecto", "Su Tipo de Usuario no esta autorizado para usar esta aplicacion.", "OK");

                    }



                }
                else
                {
                    await DisplayAlert("Usuario incorrecto", "Usuario y/o contraseña incorrectos.", "OK");
                    //LblMensaje1.IsVisible = true;
                    //LblMensaje2.IsVisible = true;   


                }
                //popupLoadingView.IsVisible = false;
                //await Task.Delay(500);
                //loader.IsRunning = false;
                //loader.IsVisible = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ocurrio un problema al verificar su login.\n "+ex.Message, "OK");

            }
            finally
            {
                loader.IsRunning = false;
                loader.IsVisible = false;
                await Task.Delay(500);
                BtnLogin.IsEnabled = true;
                BtnLogin.BackgroundColor = Color.FromRgb(4, 62, 128);
                //await sWNegocioAquacorpClient.CloseAsync();
                //sWNegocioAquacorpClient.Abort();

            }

        }

        private void TxtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            LblMensaje1.IsVisible = false;
            LblMensaje2.IsVisible = false;
        }


    }
}