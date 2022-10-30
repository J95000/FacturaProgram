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

using iText.IO.Image;
using iText.Layout.Element;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using Paragraph = iText.Layout.Element.Paragraph;
using Table = iText.Layout.Element.Table;
using iText.Layout.Borders;
using iText.Layout.Properties;
using iText.StyledXmlParser.Jsoup.Nodes;
using System.Drawing.Imaging;
using System.Drawing;
using QRCoder;
using Document = iText.Layout.Document;
using Image = iText.Layout.Element.Image;
using Cell = iText.Layout.Element.Cell;
using System.IO;
using System.Net.Mail;
using AppDistribuidor.Facturacion;

namespace AppDistribuidor.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

        public ObservableCollection<EClienteNombres> Clientess { get; set; }



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
                    CrossToastPopUp.Current.ShowToastMessage("No existe una conexion a Internet. " );
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
            if (CheckConexion())
            {

            SWNegocio.SWNegocioAquacorpClient cliente = new SWNegocio.SWNegocioAquacorpClient(SWNegocio.SWNegocioAquacorpClient.EndpointConfiguration.BasicHttpBinding_ISWNegocioAquacorp);

            List<SWNegocio.EClienteCompleja> eClienteComplejas = cliente.Obtener_Cliente().ToList();

            //List<EClienteCorta> eClienteComplejas = Task.Run(() => Obtener_Cliente()).GetAwaiter().GetResult();


            foreach (SWNegocio.EClienteCompleja item in eClienteComplejas)
            {
                EClienteNombres eClienteNombres1 = new EClienteNombres() { 
                NombreCompleto= item.Nombres + " " + item.PrimerApellido + " " + item.SegundoApellido
                };

                eClienteNombres.Add(eClienteNombres1);
                //clientes.Add(item.Nombres + " " + item.PrimerApellido + " " + item.SegundoApellido);
            }

            }
            return eClienteNombres;
        }


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
            IsBusy = true;
            Total = "Total : " + VariablesGlobales.Total;
            try
            {
                Productos.Clear();
                var productos = await DataStore.GetProductosAsync(true);
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
          var res = await DataStore.DeleteProductoAsync(producto.IdProducto);

            if(res)
            {
                VariablesGlobales.Total = VariablesGlobales.Total - (producto.Cantidad* producto.Precio);

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

        public byte[] GenerarPdf(EMovimiento eMovimientoCompleja, EDetalleMovimiento eDetalleMovimientoCompleja)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf, PageSize.A4);
                PdfFont font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);

                //LOGO EMPRESA
                ImageData imageData = ImageDataFactory.Create("https://i.pinimg.com/564x/e6/2a/60/e62a60c30bfeca030d9fbaecf1b0bbca.jpg");
                Image image = new Image(imageData);

                //DATOS A MOSTRAR EN LA FACTURA
                Paragraph datosEmpresa = new Paragraph("San Antonio\nCASA MATRIZ: Avenida Perú #349\nTeléfono: 44378234\nCochabamba - Bolivia").SetFontSize(9);
                Paragraph datosFactura = new Paragraph("NIT: 7456347832\nNo FACTURA: 2361176\nNo AUTORIZACIÓN: 296401900006126\nFEC EMISIÓN: "+ eMovimientoCompleja.FechaRegistro.ToString("dd/MM/yyyy")).SetFontSize(9);
                Paragraph datosCliente = new Paragraph(" NOMBRE / RAZÓN SOCIAL: IRIARTE\n NIT/CI: 5748345").SetFontSize(10);
                string codigoControlGenerado = CodigoControl.generateControlCode("29040011007","1503","4189179011",eMovimientoCompleja.FechaRegistro.ToString("yyyyMMdd"),"2500","9rCB7Sv4X29d)5k7N%3ab89p-3(5[A");
                Paragraph codigoControl = new Paragraph("CÓDIGO DE CONTROL: "+codigoControlGenerado).SetFontSize(10);
                
                //LINE BREAK
                Paragraph saltoLinea = new Paragraph(new Text("\n"));
                
                //CABECERA
                float[] pointColumnWidths = { 80F, 150F, 200F, 150F };
                Table tablaCabecera = new Table(pointColumnWidths);
                tablaCabecera.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(image.ScaleAbsolute(70, 70)));
                tablaCabecera.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(datosEmpresa));
                tablaCabecera.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                tablaCabecera.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(datosFactura));
                
                //CUERPO(CLIENTE)
                Table tablaCliente = new Table(1).UseAllAvailableWidth();
                tablaCliente.AddCell(new Cell().Add(datosCliente).SetPadding(7));

                //CUERPO(ARTICULOS DE VENTA)
                float[] pointColumnWidths2 = { 10F, 150F, 10F, 90F, 50F };
                Table tablaArticulosVenta = new Table(pointColumnWidths2).UseAllAvailableWidth();
                tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph("#")).SetPadding(2).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph("Descripción")).SetPadding(2).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph("Cantidad")).SetPadding(2).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph("Precio Unitario")).SetPadding(2).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph("SubTotal")).SetPadding(2).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                
                var itt = Productos;
                int indice = 1;
                foreach (var item in itt)
                {
                    tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph(indice.ToString())).SetBorder(Border.NO_BORDER).SetPadding(2).SetFontSize(10).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph(item.NombreProducto).SetMarginLeft(10)).SetBorder(Border.NO_BORDER).SetFontSize(10).SetPadding(2));
                    tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph(item.Cantidad.ToString())).SetPadding(2).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph(item.Precio.ToString())).SetPadding(2).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph((item.Cantidad*item.Precio).ToString())).SetPadding(2).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));
                    indice++;
                }
                

                //TOTAL
                Paragraph total = new Paragraph("Total: 16.00").SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
                double totalNumeros = 3.20;
                string totalNumeroALetras = NumeroALetras((decimal)totalNumeros);
                Paragraph totalEnLetras = new Paragraph("Son: " + totalNumeroALetras).SetFontSize(11);


                //PIE
                
                string dataQR = "7456347832 | 2361176 | 296401900006126 | "+ eMovimientoCompleja.FechaRegistro.ToString("yyyyMMdd") + " | "+ codigoControlGenerado + " | 5748345";
                byte[] qr = generaQR(dataQR);
                ImageData imageDataQR = ImageDataFactory.Create(qr);
                Image imageQR = new Image(imageDataQR).ScaleToFit(80f, 80f);

                Table tablaPie = new Table(2).UseAllAvailableWidth();
                tablaPie.AddCell(new Cell().Add(imageQR)).SetPadding(2);
                tablaPie.AddCell(new Cell().Add(new Paragraph("\"ESTA FACTURA CONTRIBUYE AL DESARROLLO DEL PAÍS, EL USO ÍLICITO DE ÉSTA SERÁ SANCIONADO DE ACUERDO A LA LEY\"\n" +
                                                              "Ley N° 453: Tienes derecho a un trato equitativo sin discriminación en la oferta de servicios").SetFontSize(11).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));
                
                document.Add(tablaCabecera);
                document.Add(saltoLinea);
                document.Add(tablaCliente);
                document.Add(saltoLinea);
                document.Add(tablaArticulosVenta);
                document.Add(saltoLinea);
                document.Add(total);
                document.Add(totalEnLetras);
                document.Add(saltoLinea);
                document.Add(codigoControl);
                document.Add(tablaPie);
                
                document.Close();

                return stream.ToArray();
            }
        }

        public void EnviarCorreo(string emisor, string receptor, byte[] document)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(emisor);
            mail.To.Add(receptor);
            mail.Subject = "Factura - San Antonio";
            mail.Body = "Estimado cliente, a continuación se le adjunta la factura de la compra realizada.\nGracias por su preferencia.";
            mail.Attachments.Add(new Attachment(new MemoryStream(document), "factura.pdf", "application/pdf"));


            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.EnableSsl = true;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.Credentials = new System.Net.NetworkCredential(emisor, "oelyxylccweptydo");

            SmtpServer.Send(mail);
        }

        public byte[] generaQR(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(20);
            return qrCodeBytes;
        }

        public string NumeroALetras(decimal numberAsString)
        {
            var entero = Convert.ToInt64(Math.Truncate(numberAsString));
            var decimales = Convert.ToInt32(Math.Round((numberAsString - entero) * 100, 2));
            string dec = (decimales > 0) ? $" BOLIVIANOS {decimales:0,0} /100" : $" BOLIVIANOS {decimales:0,0} /100";
            var res = NumeroALetras(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string NumeroALetras(double value)
        {
            string num2Text;
            value = Math.Truncate(value);
            if (value == 0) num2Text = "CERO";
            else if (value == 1) num2Text = "UNO";
            else if (value == 2) num2Text = "DOS";
            else if (value == 3) num2Text = "TRES";
            else if (value == 4) num2Text = "CUATRO";
            else if (value == 5) num2Text = "CINCO";
            else if (value == 6) num2Text = "SEIS";
            else if (value == 7) num2Text = "SIETE";
            else if (value == 8) num2Text = "OCHO";
            else if (value == 9) num2Text = "NUEVE";
            else if (value == 10) num2Text = "DIEZ";
            else if (value == 11) num2Text = "ONCE";
            else if (value == 12) num2Text = "DOCE";
            else if (value == 13) num2Text = "TRECE";
            else if (value == 14) num2Text = "CATORCE";
            else if (value == 15) num2Text = "QUINCE";
            else if (value < 20) num2Text = "DIECI" + NumeroALetras(value - 10);
            else if (value == 20) num2Text = "VEINTE";
            else if (value < 30) num2Text = "VEINTI" + NumeroALetras(value - 20);
            else if (value == 30) num2Text = "TREINTA";
            else if (value == 40) num2Text = "CUARENTA";
            else if (value == 50) num2Text = "CINCUENTA";
            else if (value == 60) num2Text = "SESENTA";
            else if (value == 70) num2Text = "SETENTA";
            else if (value == 80) num2Text = "OCHENTA";
            else if (value == 90) num2Text = "NOVENTA";
            else if (value < 100) num2Text = NumeroALetras(Math.Truncate(value / 10) * 10) + " Y " + NumeroALetras(value % 10);
            else if (value == 100) num2Text = "CIEN";
            else if (value < 200) num2Text = "CIENTO " + NumeroALetras(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) num2Text = NumeroALetras(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) num2Text = "QUINIENTOS";
            else if (value == 700) num2Text = "SETECIENTOS";
            else if (value == 900) num2Text = "NOVECIENTOS";
            else if (value < 1000) num2Text = NumeroALetras(Math.Truncate(value / 100) * 100) + " " + NumeroALetras(value % 100);
            else if (value == 1000) num2Text = "MIL";
            else if (value < 2000) num2Text = "MIL " + NumeroALetras(value % 1000);
            else if (value < 1000000)
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) num2Text = num2Text + " " + NumeroALetras(value % 1000);
            }
            else if (value == 1000000) num2Text = "UN MILLON";
            else if (value < 2000000) num2Text = "UN MILLON " + NumeroALetras(value % 1000000);
            else if (value < 1000000000000)
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                    num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000) * 1000000);
            }
            else if (value == 1000000000000) num2Text = "UN BILLON";
            else if (value < 2000000000000) num2Text = "UN BILLON " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                    num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return num2Text;
        }
    }
}