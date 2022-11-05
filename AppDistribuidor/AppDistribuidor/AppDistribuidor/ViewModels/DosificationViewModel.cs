using AppDistribuidor.Models;
using Newtonsoft.Json;
using SWNegocio;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDistribuidor.ViewModels
{
    public class DosificationViewModel : BaseViewModel
    {
        public DosificationViewModel()
        {
            Title = "Datos Facturacion";
            fechaLimiteEmision = DateTime.Now;
            IsBusy = true;
        }
        #region Properties
        private string autorizacion;
        private string llaveDosificacion;
        private DateTime fechaLimiteEmision;
        #endregion
        #region GeterSeter
        public DateTime FechaLimiteEmision
        {
            get { return fechaLimiteEmision; }
            set { SetProperty(ref fechaLimiteEmision, value); }

        }

        public string LLaveDosificacion
        {
            get { return llaveDosificacion; }
            set { SetProperty(ref llaveDosificacion, value); }
        }


        public string Autorizacion
        {
            get { return autorizacion; }
            set { SetProperty(ref autorizacion, value); }
        }
        #endregion

        #region Commands
        public ICommand RegistryDosificationCommand
        {
            get
            {
                return new Command(async() =>
                {
                    try
                    {
                        if(!string.IsNullOrWhiteSpace(autorizacion) && !string.IsNullOrWhiteSpace(llaveDosificacion.Trim()))
                        {
                            IsBusy = false;

                            EDosificacionCompleja eDosificacionCompleja = new EDosificacionCompleja()
                            {
                                NroAutorizacion = autorizacion,
                                LlaveDosificacion = llaveDosificacion,
                                FechaLimite = fechaLimiteEmision
                            };

                            using (HttpClient cliente = new HttpClient())
                            {
                                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                                {
                                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                                };
                                //POST Request
                                string requestUrl = "http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Insertar_Dosificacion";


                                string jsonString = JsonConvert.SerializeObject(eDosificacionCompleja, microsoftDateFormatSettings);
                                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                var request = new StringContent(jsonString, Encoding.UTF8, "application/json");
                                var response = cliente.PostAsync(requestUrl, request).Result;
                                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                                if (result == "true")
                                {
                                    await App.Current.MainPage.DisplayAlert("Correcto!", "La dosificacion se inserto de manera correcta", "Aceptar");
                                }
                                else
                                {
                                    await App.Current.MainPage.DisplayAlert("Error", "No se Pudo Insertar la Dosificacion", "Aceptar");
                                }
                            }
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", "Debe Llenar Todos Los Campos", "Aceptar");

                        }


                    }
                    catch (Exception ex)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", ex.Message.ToString(), "Cerrar");
                    }
                    IsBusy = true;
                });
            }
        }
        #endregion
    }
}