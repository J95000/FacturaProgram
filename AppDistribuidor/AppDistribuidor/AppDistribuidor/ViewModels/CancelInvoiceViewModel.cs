using AppDistribuidor.Facturacion;
using AppDistribuidor.Models;
using AppDistribuidor.Services;
using Newtonsoft.Json;
using SWNegocio;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppDistribuidor.ViewModels
{
    public class CancelInvoiceViewModel : BaseViewModel
    {
        #region Attributes
        private string controlCode;
        private int userId;

        #endregion

        #region Properties
        public string ControlCode
        {
            get { return controlCode; }
            set { SetProperty(ref controlCode, value); }
        }
        public int UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }
        #endregion

        public CancelInvoiceViewModel()
        {
            Title = "Buscar y Anular Factura";
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


                        var responseStringM = await client.GetStringAsync($"http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Movimiento_CodigoControl/{controlCode}/{7}");
                        string resp = Convert.ToString(responseStringM);
                        var obj = JsonConvert.DeserializeObject<object>(resp);
                        string data = Convert.ToString(obj);
                        EMovimientoCompleja eMovimientoCompleja = new EMovimientoCompleja();
                        eMovimientoCompleja = JsonConvert.DeserializeObject<EMovimientoCompleja>(data);


                        var responseStringDM = await client.GetStringAsync($"http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_DetalleMovimiento_IdMovimiento_Lista/{eMovimientoCompleja.IdMovimiento}");
                        string respDM = Convert.ToString(responseStringDM);
                        var objDM = JsonConvert.DeserializeObject<object>(resp);
                        string dataDM = Convert.ToString(objDM);
                        ObservableCollection<EDetalleMovimientoCompleja> lista = new ObservableCollection<EDetalleMovimientoCompleja>();
                        eMovimientoCompleja = JsonConvert.DeserializeObject<EMovimientoCompleja>(dataDM);

                        EMovimiento eMovimiento = new EMovimiento()
                        {
                            IdCliente = 1,
                            NombreCliente = "Juan Perez",
                            NitCi = "13623834018",
                            NroMovimiento = 1,
                            CodigoControl = "33-86-AD-50",
                            PrecioTotal = 26,
                            FechaRegistro = DateTime.Now,
                            RazonSocial = "Juan Perez"

                        };
                        ObservableCollection<ProductoVenta> productos = new ObservableCollection<ProductoVenta>();
                        productos.Add(new ProductoVenta { IdProducto = 1, Cantidad = 2, Precio = 10, NombreProducto = "Botellon Azul" });
                        productos.Add(new ProductoVenta { IdProducto = 2, Cantidad = 1, Precio = 8, NombreProducto = "Botellon Verde" });

                        GenerarFactura generarFactura = new GenerarFactura();
                        byte[] pdf = generarFactura.GenerarPdf(productos, eMovimiento, new EDetalleMovimiento());
                        await DependencyService.Get<IPdfViewer>().Open(pdf,1);

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
