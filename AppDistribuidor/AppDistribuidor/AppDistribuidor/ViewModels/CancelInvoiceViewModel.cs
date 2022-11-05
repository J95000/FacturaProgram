using AppDistribuidor.Facturacion;
using AppDistribuidor.Models;
using AppDistribuidor.Services;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDistribuidor.ViewModels
{
    public class CancelInvoiceViewModel : BaseViewModel
    {
        public CancelInvoiceViewModel()
        {
            Title = "Anular Factura";
        }
        //TODO: comando de busqueda
        //TODO: 6
        //TODO: 7
        public ICommand SearchInvoiceCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        var client = new HttpClient();
                        //poner el endpoint de la bsuqueda del movimiento
                        //poner el endpoint de la busqueda del detalle
                        //total 2 consultas que generaran 2 objetos

                        /*
                         //ejemplo consulta
                        var responseString = await client.GetStringAsync("http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Usuario_Empleado_Ci");
                        string resp = Convert.ToString(responseString);
                        var obj = JsonConvert.DeserializeObject<object>(resp);
                        string data = Convert.ToString(obj);
                        EUsuario eUsuarioCompleja = new EUsuario();
                        eUsuarioCompleja = JsonConvert.DeserializeObject<EUsuario>(data);*/
                        EMovimiento eMovimiento = new EMovimiento()
                        {
                            IdCliente = 1,
                            NombreCliente = "Juan Perez",
                            NitCi = "13623834018",
                            NroMovimiento = 1,
                            CodigoControl = "33-86-AD-50",
                            PrecioTotal = 26,
                            FechaRegistro=DateTime.Now,
                            RazonSocial= "Juan Perez"

                        };
                        ObservableCollection<ProductoVenta> productos = new ObservableCollection<ProductoVenta>();
                        productos.Add(new ProductoVenta { IdProducto = 1, Cantidad = 2, Precio = 10, NombreProducto = "Botellon Azul" });
                        productos.Add(new ProductoVenta { IdProducto = 2, Cantidad = 1, Precio = 8, NombreProducto = "Botellon Verde" });

                        GenerarFactura generarFactura = new GenerarFactura();
                        byte[] pdf = generarFactura.GenerarPdf(productos, eMovimiento, new EDetalleMovimiento());
                        await DependencyService.Get<IPdfViewer>().Open(pdf);

                    }
                    catch (Exception e)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", e.Message.ToString(), "Cerrar");
                    }
                });
            }
        }

    }
}
