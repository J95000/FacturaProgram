using AppDistribuidor.Models;
using AppDistribuidor.Views;
using Plugin.Connectivity;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDistribuidor.ViewModels
{
    public class ItemsViewModelPrestamo : BaseViewModelPrestamo
    {
        public ObservableCollection<EClienteNombres> Clientess { get; set; }


        private ProductoPrestamo _selectedProducto;
        public ObservableCollection<ProductoPrestamo> Productos { get; }
        public Command LoadProductosCommand { get; }
        public Command AddProductoCommand { get; }
        public Command BorrarTodoCommand { get; }
        public Command<ProductoPrestamo> ProductoTapped { get; }

        public Command<ProductoPrestamo> ProductoEliminar { get; }

        private string total;
        public string nombreCliente;


        public ItemsViewModelPrestamo()
        {
           // Title = "Prestamos";

            Productos = new ObservableCollection<ProductoPrestamo>();

            LoadProductosCommand = new Command(async () => await ExecuteLoadProductosCommand());

            ProductoTapped = new Command<ProductoPrestamo>(OnProductoSelected);

            AddProductoCommand = new Command(OnAddProducto);

            ProductoEliminar = new Command<ProductoPrestamo>(OnProductoBorrar);

            BorrarTodoCommand = new Command(BorrarTodo);



            Clientess = ListarClientes();


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
                    CrossToastPopUp.Current.ShowToastMessage("No existe una conexion a Internet. ");
                    // DisplayAlert("Conexión a Internet", "No existe una conexion a Internet. \n Por favor Conectese a internet eh intente de nuevo.", "OK");
                    ban = false;
                }
            }
            catch (Exception ex)
            {
                // DisplayAlert("Error", "Ocurrio un problema al verificar conexion a internet.\n " + ex.Message, "OK");
                CrossToastPopUp.Current.ShowToastMessage("Ocurrio un problema al verificar conexion a internet.");
            }
            return ban;

        }
        public ObservableCollection<EClienteNombres> ListarClientes()
        {
            //clientes = new List<string>();

            ObservableCollection<EClienteNombres> eClienteNombres = new ObservableCollection<EClienteNombres>();
            if(CheckConexion())
            {

           
            SWNegocio.SWNegocioAquacorpClient cliente = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);

            List<SWNegocio.EClienteCompleja> eClienteComplejas = cliente.Obtener_Cliente().ToList();

            //List<EClienteCorta> eClienteComplejas = Task.Run(() => Obtener_Cliente()).GetAwaiter().GetResult();


            foreach (SWNegocio.EClienteCompleja item in eClienteComplejas)
            {
                EClienteNombres eClienteNombres1 = new EClienteNombres()
                {
                    NombreCompleto = item.Nombres + " " + item.PrimerApellido + " " + item.SegundoApellido
                };

                eClienteNombres.Add(eClienteNombres1);
                    //clientes.Add(item.Nombres + " " + item.PrimerApellido + " " + item.SegundoApellido);
                }
            }
            return eClienteNombres;
        }
        public async void BorrarTodo()
        {
            VariablesGlobales.TotalPrestamo = 0;
            IsBusy = true;
            Total = "Total : " + VariablesGlobales.TotalPrestamo;
            try
            {
                Productos.Clear();
                var productos = await DataStorePrestamos.BorrarProductosAsync(true);
                foreach (var producto in productos)
                {
                    Productos.Add(producto);
                }

                NombreCliente = string.Empty;
                CrossToastPopUp.Current.ShowToastMessage("Campos borrados. ");
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
        async Task ExecuteLoadProductosCommand()
        {
            IsBusy = true;
            Total = "Total : " + VariablesGlobales.TotalPrestamo;
            try
            {
                Productos.Clear();
                var productos = await DataStorePrestamos.GetProductosAsync(true);
                foreach (var producto in productos)
                {
                    Productos.Add(producto);
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
        public void OnAppearing()
        {
            IsBusy = true;
    
            SelectedProducto = null;
        }
        public string Total
        {
            get => total;
            set => SetProperty(ref total, value);
        }


        public ProductoPrestamo SelectedProducto
        {
            get => _selectedProducto;
            set
            {
                SetProperty(ref _selectedProducto, value);
                OnProductoSelected(value);
            }
        }
        public string NombreCliente
        {
            get => nombreCliente;
            set => SetProperty(ref nombreCliente, value);
        }
     
        private async void OnAddProducto(object obj)
        {
            //await Shell.Current.GoToAsync(nameof(NewItemPage));
            await Shell.Current.GoToAsync(nameof(NewItemPage2));
            Total = "Total: " + VariablesGlobales.TotalPrestamo + "";
        }

        async void OnProductoSelected(ProductoPrestamo producto)
        {
            if (producto == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={producto.IdProducto}");
        }
        private async void OnProductoBorrar(ProductoPrestamo producto)
        {
            //ProductoVenta productoVenta = (ProductoVenta)obj;
            var res = await DataStorePrestamos.DeleteProductoAsync(producto.IdProducto);

            if (res)
            {
                VariablesGlobales.TotalPrestamo = VariablesGlobales.TotalPrestamo - (producto.Cantidad * producto.Precio);

                await ExecuteLoadProductosCommand();
                CrossToastPopUp.Current.ShowToastMessage("Producto borrado de lista. ");
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("Problema al borrar producto. ");
            }


            //await Shell.Current.GoToAsync(nameof(NewItemPage));
            // This will push the ItemDetailPage onto the navigation stack
            // await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={producto.IdProducto}");
        }




    }
}
