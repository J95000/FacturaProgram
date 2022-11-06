using AppDistribuidor.Facturacion;
using AppDistribuidor.Models;
using AppDistribuidor.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            IsBusy = true;
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
                        IsBusy = false;
                        var client = new HttpClient();
                        //poner el endpoint de la bsuqueda del movimiento
                        //poner el endpoint de la busqueda del detalle
                        //total 2 consultas que generaran 2 objetos


                        var responseStringM = await client.GetStringAsync($"http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Movimiento_CodigoControl/{controlCode}/{7}");
                        string resp = Convert.ToString(responseStringM);
                        var obj = JsonConvert.DeserializeObject<object>(resp);
                        string data = Convert.ToString(obj);
                        EMovimiento eMovimiento = new EMovimiento();
                        eMovimiento = JsonConvert.DeserializeObject<EMovimiento>(data);
                        if(eMovimiento.IdMovimiento!=0)
                        {
                            var responseDetalleM = await client.GetStringAsync($"http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_DetalleMovimiento_IdMovimiento_Lista/{eMovimiento.IdMovimiento}");
                            string respDM = Convert.ToString(responseDetalleM);
                            List<Models.EDetalleMovimientoCompleja> detailMList = JsonConvert.DeserializeObject<List<Models.EDetalleMovimientoCompleja>>(respDM);



                            ObservableCollection<ProductoVenta> productos = new ObservableCollection<ProductoVenta>();
                            foreach (var item in detailMList)
                            {
                                /*
                                 * Remplanzar a esta consulta cuando el end potin http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_DetalleMovimiento_IdMovimiento_Lista/{eMovimiento.IdMovimiento}
                                 * retorne correctamente el nombre del producto
                                productos.Add(new ProductoVenta { Cantidad = item.Cantidad, Precio = item.PrecioUnitario, NombreProducto = item.NombreProducto });
                                */
                                var productoAux = await client.GetStringAsync($"http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Producto_Id_Producto/{item.IdProducto}");
                                string resProductoAux = Convert.ToString(productoAux);
                                ProductoVenta paux = JsonConvert.DeserializeObject<ProductoVenta>(resProductoAux);
                                productos.Add(new ProductoVenta { Cantidad = item.Cantidad, Precio = item.PrecioUnitario, NombreProducto = paux.NombreProducto });

                            }
                            GenerarFactura generarFactura = new GenerarFactura();

                            var resDosification = await client.GetStringAsync($"http://www.aquacorpmovil.somee.com/SWNegocioMovil.svc/Obtener_Dosificacion_IdDosificacion/{eMovimiento.IdDosificacion}");
                            string stringdisification = Convert.ToString(resDosification);
                            EDosificacionCompleja eDosificacionCompleja = JsonConvert.DeserializeObject<EDosificacionCompleja>(stringdisification);

                            byte[] pdf = generarFactura.GenerarPdf(productos, eMovimiento, new EDetalleMovimiento(), eDosificacionCompleja);
                            await DependencyService.Get<IPdfViewer>().Open(pdf, eMovimiento.IdMovimiento);
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", $"La Factura con Codigo de Control: \n {controlCode} . No existe o esta Inhabilidada", "Cerrar");
                        }
                    }
                    catch (Exception e)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", e.Message.ToString(), "Cerrar");
                    }
                    finally
                    {
                        IsBusy = true;
                    }
                });
            }
        }
    }
}
