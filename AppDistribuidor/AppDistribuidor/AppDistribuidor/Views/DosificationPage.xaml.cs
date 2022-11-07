using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppDistribuidor.Models;
using Newtonsoft.Json;
using SWNegocio;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDistribuidor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DosificationPage : ContentPage
    {
        public DosificationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método para obtener la dosificación habilitada y mostrar si sigue activa o ya no es vigente
        /// </summary>
        protected override void OnAppearing()
        {
            //Instancia de la clase EDosificacionCompleja
            EDosificacionCompleja eDosificacionCompleja = new EDosificacionCompleja();
            //Llenando la instancia con los datos recibidos del metodo Obtener_Dosificacion_Habilitado
            eDosificacionCompleja = Task.Run(() => Obtener_Dosificacion_Habilitado()).GetAwaiter().GetResult();
            //Entra al if si hay una dosificacion vigente
            if (eDosificacionCompleja.IdDosificacion != 0 && eDosificacionCompleja.FechaLimite > DateTime.Now)
            {
                string fechaLimite = eDosificacionCompleja.FechaLimite.ToString("yyyy-MM-dd");
                mensajeAlertaError.Text = $"Fecha Limite de Emisión Dosificación Activa: {fechaLimite}";
            }
            //Entra al else si no hay dosificacion o si su fecha limite ya caducó
            else
            {
                mensajeAlertaError.Text = "No Existe una Dosificación Vigente";
            }
        }

        /// <summary>
        /// Método para buscar la dosificación habilitada y enviarlo
        /// </summary>
        /// <returns>Dosificación Habilitada</returns>
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
    }
}