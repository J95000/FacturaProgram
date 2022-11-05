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

namespace AppDistribuidor.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

        public ObservableCollection<EClienteNombres> Clientess { get; }

        public Command BuscarClientesCommand { get; }

        private ProductoVenta _selectedProducto;
        public ObservableCollection<ProductoVenta> Productos { get; }
        public Command LoadProductosCommand { get; }
        public Command AddProductoCommand { get; }

        public Command BorrarTodoCommand { get; }
        public Command<ProductoVenta> ProductoTapped { get; }

        public Command<ProductoVenta> ProductoEliminar { get; }

        private string total;
        public string nombreCliente;

        //public string nombreCompleto;


        public ItemsViewModel()
        {
            //LimpiarTodo();

            Title = "Ventas";

            Productos = new ObservableCollection<ProductoVenta>();

            LoadProductosCommand = new Command(async () => await ExecuteLoadProductosCommand());

            ProductoTapped = new Command<ProductoVenta>(OnProductoSelected);

            AddProductoCommand = new Command(OnAddProducto);

            ProductoEliminar = new Command<ProductoVenta>(OnProductoBorrar);

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


            ObservableCollection<EClienteNombres> eClienteNombres = new ObservableCollection<EClienteNombres>();
            //if (CheckConexion())
            //{

            //    SWNegocio.SWNegocioAquacorpClient cliente = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);

            //    List<SWNegocio.EClienteCompleja> eClienteComplejas = cliente.Obtener_Cliente().ToList();

            //    //List<EClienteCorta> eClienteComplejas = Task.Run(() => Obtener_Cliente()).GetAwaiter().GetResult();


            //    foreach (SWNegocio.EClienteCompleja item in eClienteComplejas)
            //    {
            //        EClienteNombres eClienteNombres1 = new EClienteNombres()
            //        {
            //            NombreCompleto = item.Nombres + " " + item.PrimerApellido + " " + item.SegundoApellido
            //        };

            //        eClienteNombres.Add(eClienteNombres1);
            //        //clientes.Add(item.Nombres + " " + item.PrimerApellido + " " + item.SegundoApellido);
            //    }

            //}


            //Console.WriteLine($"-----SE ESTA BUSCANDO =====   " + nombreCliente + " -----");
            //Console.WriteLine($"-----SE ESTA BUSCANDO =====   " + nombreCliente + " -----");
            //Console.WriteLine($"-----SE ESTA BUSCANDO =====   " + nombreCliente + " -----");
            //Console.WriteLine($"-----SE ESTA BUSCANDO =====   " + nombreCliente + " -----");
            return eClienteNombres;
        }


        //public ObservableCollection<EClienteNombres> ListarClientes()
        //{


        //    ObservableCollection<EClienteNombres> eClienteNombres = new ObservableCollection<EClienteNombres>();
        //    if (CheckConexion())
        //    {

        //    SWNegocio.SWNegocioAquacorpClient cliente = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);

        //    List<SWNegocio.EClienteCompleja> eClienteComplejas = cliente.Obtener_Cliente().ToList();

        //    //List<EClienteCorta> eClienteComplejas = Task.Run(() => Obtener_Cliente()).GetAwaiter().GetResult();


        //    foreach (SWNegocio.EClienteCompleja item in eClienteComplejas)
        //    {
        //        EClienteNombres eClienteNombres1 = new EClienteNombres() { 
        //        NombreCompleto= item.Nombres + " " + item.PrimerApellido + " " + item.SegundoApellido
        //        };

        //        eClienteNombres.Add(eClienteNombres1);
        //        //clientes.Add(item.Nombres + " " + item.PrimerApellido + " " + item.SegundoApellido);
        //    }

        //    }

        //    return eClienteNombres;
        //}


        public async void BorrarTodo()
        {
            VariablesGlobales.Total = 0;
            IsBusy = true;
            Total = "Total : " + VariablesGlobales.Total;
            try
            {
                Productos.Clear();
                var productos = await DataStore.BorrarProductosAsync(true);
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
            ProductoVenta producto = new ProductoVenta();

            IsBusy = true;
            Total = "Total : " + VariablesGlobales.Total;
            try
            {
                Productos.Clear();
                var productos = await DataStore.GetProductosAsync(true);


                var query = (from t in productos
                             group t by new { t.IdProducto, t.NombreProducto, t.Precio }
                              into grp
                             select new
                             {
                                 grp.Key.IdProducto,
                                 grp.Key.NombreProducto,
                                 Cantidad = grp.Sum(t => t.Cantidad),
                                 grp.Key.Precio
                             }).ToList();

                foreach (var item in query)
                {
                    producto = new ProductoVenta() { 
                    IdProducto = item.IdProducto,
                    NombreProducto = item.NombreProducto,
                    Cantidad= byte.Parse(item.Cantidad.ToString()),
                    Precio=item.Precio
                    
                    };

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
            //  SelectedItem = null;
            SelectedProducto = null;

        }

        public string Total
        {
            get => total;
            set => SetProperty(ref total, value);
        }

        public string NombreCliente
        {
            get => nombreCliente;
            set => SetProperty(ref nombreCliente, value);
        }



        public ProductoVenta SelectedProducto
        {
            get => _selectedProducto;
            set
            {
                SetProperty(ref _selectedProducto, value);
                OnProductoSelected(value);
            }
        }


        private async void OnAddProducto(object obj)
        {

            await Shell.Current.GoToAsync(nameof(NewItemPage));

            Total = "Total: " + VariablesGlobales.Total + "";


        }

        private async void OnProductoBorrar(ProductoVenta producto)
        {
            //ProductoVenta productoVenta = (ProductoVenta)obj;
            var res = await DataStore.DeleteProductoAsync(producto.IdProducto,producto.Precio);

            if (res)
            {
                VariablesGlobales.Total = VariablesGlobales.Total - (producto.Cantidad * producto.Precio);

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

        async void OnProductoSelected(ProductoVenta producto)
        {
            if (producto == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={producto.IdProducto}");
        }

    }
}