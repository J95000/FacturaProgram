using AppDistribuidor.Models;
using AppDistribuidor.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;
using Plugin.Toast;
using Plugin.Connectivity;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AppDistribuidor.ViewModels
{
    public class GastoViewModel : BaseModelGasto
    {
        private EGasto _selectedItem;

        public ObservableCollection<EGasto> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<EGasto> ItemTapped { get; }
        public Command<EGasto> ItemTappedd { get; }
        //public Command SalirCommand { get; }

        public GastoViewModel()
        {
            // Title = "Producción de " + Task.Run(() => ObtenerFechaZonaLocalAsync()).GetAwaiter().GetResult().ToShortDateString();

            Title = "Gastos";


            Items = new ObservableCollection<EGasto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<EGasto>(OnItemSelected);
            ItemTappedd = new Command<EGasto>(OnItemEliminar);

            AddItemCommand = new Command(OnAddItem);
            //SalirCommand = new Command(Salir);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                if (CheckConexion())
                {
                    Items.Clear();

                    var items = await DataGasto.GetItemsAsync(true);

                    foreach (var item in items)
                    {

                        Items.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }



 

        public bool CheckConexion()
        {
            bool ban = false;

            if (CrossConnectivity.Current.IsConnected)
            {
                ban = true;
            }
            else
            {
                ban = false;
            }

            return ban;

        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public EGasto SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NuevoGastoPage));
        }

       

        async void OnItemSelected(EGasto item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.IdGasto}");
        }
        public static async Task<EGasto> Obtener_Gasto_Id_Gasto(string IdGasto)
        {
            var client = new HttpClient();
            var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Gasto_Id_Gasto" + "/" + IdGasto);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            EGasto eExistenciaCortaCompleja = JsonConvert.DeserializeObject<EGasto>(data);
            return eExistenciaCortaCompleja;

        }


        public static async Task<bool> Actualizar_Gasto(EGasto eEGasto)
        {

            using (HttpClient cliente = new HttpClient())
            {
                JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                //POST Request
                string requestUrl = "http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Actualizar_Gasto";


                string jsonString = JsonConvert.SerializeObject(eEGasto, microsoftDateFormatSettings);
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = cliente.PostAsync(requestUrl, request).Result;
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (result == "true") return true;
                else return false;
            }


        }

        async void OnItemEliminar(EGasto item)
        {
            //await Task.Delay(100);
            if (item == null)
                return;

            //SWNegocio.SWNegocioAquacorpClient cliente = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);
            //SWNegocio.EExistenciaCompleja eExistenciaCompleja = cliente.Obtener_Existencia_Id_Existencia(item.Id);


            EGasto eEGasto = Task.Run(() => Obtener_Gasto_Id_Gasto(item.IdGasto.ToString())).GetAwaiter().GetResult();

            EGasto eEGastoMod = new EGasto()
            {


                Cantidad = eEGasto.Cantidad,
                Cont = eEGasto.Cont,
                Estado = "IN",
                FechaModificacion = eEGasto.FechaModificacion,
                FechaRegistro = eEGasto.FechaRegistro,
                IdAprovador = eEGasto.IdAprovador,
                IdGasto = eEGasto.IdGasto,
                IdTipoGasto = eEGasto.IdTipoGasto,
                IdUsuario = eEGasto.IdUsuario,
                NombreTipoGasto = eEGasto.NombreTipoGasto,
                Precio = eEGasto.Precio



            };
      
            bool res = Task.Run(() => Actualizar_Gasto(eEGastoMod)).GetAwaiter().GetResult();

            if (res)
                CrossToastPopUp.Current.ShowToastMessage("Gasto borrado con exito.");
            else
                CrossToastPopUp.Current.ShowToastMessage("Error al borrar Gasto.\n Intente de nuevo.");
            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");

            await DataGasto.VolverLlenarAsync();


            await ExecuteLoadItemsCommand();
            await Shell.Current.GoToAsync("..");
            //Application.Current.MainPage = new ItemsPage();
        }


    }
}
