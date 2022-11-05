using Newtonsoft.Json;
using SWNegocio;
using System;
using System.Net.Http;
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
                        IsBusy = false;
                        var client = new HttpClient();

                        string contents = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Dosificacion_Habilitado");
                        string resp = Convert.ToString(contents);
                        var obj = JsonConvert.DeserializeObject<object>(resp);
                        string data = Convert.ToString(obj);
                        EMovimientoCompleja eMovimientoCompleja = new EMovimientoCompleja();
                        eMovimientoCompleja = JsonConvert.DeserializeObject<EMovimientoCompleja>(data);

                        await App.Current.MainPage.DisplayAlert("Atencion!", "echo", "Cerrar");
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