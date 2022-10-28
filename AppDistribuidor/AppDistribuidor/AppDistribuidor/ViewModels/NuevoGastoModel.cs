using AppDistribuidor.Models;
using Newtonsoft.Json;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDistribuidor.ViewModels
{
    public class NuevoGastoModel : BaseModelGasto
    {
        private string cantidad;
        private string tipoGasto;
        private string precio;

        public NuevoGastoModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        private bool ValidateSave()
        {


            return !String.IsNullOrWhiteSpace(cantidad) && !String.IsNullOrWhiteSpace(tipoGasto) && !String.IsNullOrWhiteSpace(precio);
        }

        public string Cantidad
        {
            get => cantidad;
            set => SetProperty(ref cantidad, value);
        }
        public string Precio
        {
            get => precio;
            set => SetProperty(ref precio, value);
        }
        public string TipoGasto
        {
            get => tipoGasto;
            set => SetProperty(ref tipoGasto, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        public static async Task<bool> Insertar_GastoAsync(EGasto eEGasto)
        {

            using (HttpClient cliente = new HttpClient())
            {
                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                //POST Request
                string requestUrl = "http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Insertar_Gasto";


                string jsonString = JsonConvert.SerializeObject(eEGasto, microsoftDateFormatSettings);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = cliente.PostAsync(requestUrl, request).Result;
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (result == "true") return true;
                else return false;
            }


        }


        private async void OnSave()
        {

              try
            {
                int canti;
                double preci;
                if (int.TryParse(Cantidad, out canti))
                {
                    if (canti > 0)
                    {
                        if (double.TryParse(Precio, out preci))
                        {
                            if (preci > 0)
                            {
                                string prec = Precio.Replace('.',',');

                                EGasto eEGasto = new EGasto()
                        {
                                Cantidad = int.Parse(Cantidad),
                            Cont = 0,
                            Estado = "HA",
                            FechaModificacion = DateTime.Now,
                            FechaRegistro = DateTime.Now,
                            IdAprovador = VariablesGlobales.IdUsuario,
                            IdGasto = 0,
                            IdTipoGasto = VariablesGlobales.idTipoGasto,
                            IdUsuario = VariablesGlobales.IdUsuario,
                            NombreTipoGasto = TipoGasto,
                            Precio = decimal.Parse(prec)

                        };
                        bool res = await Insertar_GastoAsync(eEGasto);
                        if (res)
                            CrossToastPopUp.Current.ShowToastMessage("Gasto registrado con exito.");
                        else
                            throw new Exception();   // CrossToastPopUp.Current.ShowToastMessage("Error al registrada Existencia.\n Intente de nuevo.");

 

                        await DataGasto.VolverLlenarAsync();

                        // This will pop the current page off the navigation stack
                        await Shell.Current.GoToAsync("..");
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("Precio", "El precio no puede ser menor a 0", "Ok");
                            }
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Precio", "El precio es incorrecto", "Ok");
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Cantidad", "La cantidad no puede ser menor a 1", "Ok");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Cantidad", "La cantidad es incorrecta", "Ok");
                }

            }
            catch (Exception)
            {

                await App.Current.MainPage.DisplayAlert("Registro", "Ocurrio un error al registrar. \n Intente de nuevo.", "Ok");
            }
            
        }

    }
}
