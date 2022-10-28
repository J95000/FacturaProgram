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
using Plugin.Toast;

namespace AppDistribuidor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordChangePage : ContentPage
    {
        public PasswordChangePage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (CheckConexion())
            {
                CambioContrasena();
            }
        }
        protected override bool OnBackButtonPressed()
        {
            //if (await DisplayAlert("", "Esta seguro salir? \n Los cambios no se guardaran.", "Si", "No"))
            //    return false;

            return false;
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
            catch (Exception)
            {
                DisplayAlert("Error", "Ocurrio un problema al verificar conexion a internet.\n ", "OK");

            }
            return ban;

        }




        public static async Task<bool> Restablecer_Contrasena_Usuario( string contra,string Idusuario)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Restablecer_Contrasena_Usuario" + "/" + contra + "/" + Idusuario).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (responseContent == "true") return true;
            else return false;

        }

        public async void CambioContrasena()
        {
            //SWNegocioAquacorpClient sWNegocioAquacorpClient = new SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);
            try
            {
                loader.IsRunning = true;
                loader.IsVisible = true;
                LblNombre.IsVisible = false;
                if (TxtContrasena1.Text.Trim() == TxtContrasena2.Text.Trim())
                {

                    if (VariablesGlobales.Contrasena != TxtContrasena1.Text.Trim())
                    {
                       // sWNegocioAquacorpClient.Restablecer_Contrasena_Usuario(TxtContrasena2.Text.Trim().ToUpper(), VariablesGlobales.IdUsuario);


                        bool res = Task.Run(() => Restablecer_Contrasena_Usuario(TxtContrasena2.Text.Trim(), VariablesGlobales.IdUsuario.ToString())).GetAwaiter().GetResult();
                       if(res)
                            CrossToastPopUp.Current.ShowToastMessage("Contraseña restablecida con exito. " );


                        TxtContrasena1.IsVisible = false;
                        TxtContrasena2.IsVisible = false;
                        BtnLogin.IsVisible = false;
                        LblMensaje3.IsVisible = true;
                        await Task.Delay(3000);
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        await DisplayAlert("Contraseñas", "La contraseña nueva no puede ser igual a la antigua.\n Intenta de nuevo.", "OK");
                        TxtContrasena1.Text = "";
                        TxtContrasena2.Text = "";
                        TxtContrasena1.Focus();
                    }
                }
                else
                {
                    await DisplayAlert("Contraseña", "Las contraseñas no coinciden.\n Intenta de nuevo.", "OK");
                    TxtContrasena1.Text = "";
                    TxtContrasena2.Text = "";
                    TxtContrasena1.Focus();
                }

                await Task.Delay(500);
                loader.IsRunning = false;
                loader.IsVisible = false;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Ocurrio un problema al verificar su Contraseña.\n Intenta de nuevo.", "OK");

            }
            finally
            {
                //await sWNegocioAquacorpClient.CloseAsync();
                //sWNegocioAquacorpClient.Abort();
                loader.IsRunning = false;
                loader.IsVisible = false;
                LblNombre.IsVisible = true;
            }

        }

    }
}