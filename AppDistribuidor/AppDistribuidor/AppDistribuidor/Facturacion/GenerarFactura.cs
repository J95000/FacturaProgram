using AppDistribuidor.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
using System.Collections.ObjectModel;
using iText.Kernel.Colors;
using Color = iText.Kernel.Colors.Color;

namespace AppDistribuidor.Facturacion
{
    public class GenerarFactura
    {
        /// <summary>
        /// Metodo que genera un PDF recibiendo cuatro parametros
        /// </summary>
        /// <param name="Productos"></param>
        /// <param name="eMovimientoCompleja"></param>
        /// <param name="eDetalleMovimientoCompleja"></param>
        /// <param name="eDosificacionCompleja"></param>
        /// <returns>Retorna un arreglo de bytes para su posterior envio mediante correo</returns>
        public byte[] GenerarPdf(ObservableCollection<ProductoVenta> Productos, EMovimiento eMovimientoCompleja, EDetalleMovimiento eDetalleMovimientoCompleja, EDosificacionCompleja eDosificacionCompleja)
        {
            //Creamos un flujo de memoria para el PDF
            using (MemoryStream stream = new MemoryStream())
            {
                //Creamos instancia de los objetos necesarios para construir la estructura del PDF
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf, PageSize.A4);
                PdfFont font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
                PdfFont fontTitulo = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.TIMES_ROMAN);

                //Instancia del logo de la empresa
                ImageData imageData = ImageDataFactory.Create("https://i.pinimg.com/564x/e6/2a/60/e62a60c30bfeca030d9fbaecf1b0bbca.jpg");
                Image image = new Image(imageData);

                //Datos de la empresa, factura y del cliente a mostrar
                Paragraph datosEmpresa = new Paragraph("AQUACORP S.R.L.\nCASA MATRIZ: Calle Gral. Jose Ballivian \nNro. S/n\nTeléfono: 4245055-48360300\nCochabamba - Bolivia").SetFontSize(9);
                Paragraph datosFactura = new Paragraph("NIT: 395410026\nNo FACTURA: " + eMovimientoCompleja.NroMovimiento.ToString() + "\nNo AUTORIZACIÓN: " + eDosificacionCompleja.NroAutorizacion).SetFontSize(9);
                Paragraph tituloFactura = new Paragraph("FACTURA\n(Con Derecho a Crédito Fiscal)").SetFont(fontTitulo).SetFontSize(13).SetTextAlignment(TextAlignment.CENTER);
                Paragraph datosCliente = new Paragraph(" NOMBRE / RAZÓN SOCIAL: " + eMovimientoCompleja.RazonSocial + "\n NIT/CI: " + eMovimientoCompleja.NitCi + "\nFECHA EMISIÓN: "+ eMovimientoCompleja.FechaRegistro.ToString("dd/MM/yyyy")).SetFontSize(10);
                Paragraph codigoControl = new Paragraph("CÓDIGO DE CONTROL: " + eMovimientoCompleja.CodigoControl).SetFontSize(10);

                //Instancia de salto de linea
                Paragraph saltoLinea = new Paragraph(new Text("\n"));

                //Cabecera del PDF
                float[] pointColumnWidths = { 80F, 260F, 100F, 150F };
                Table tablaCabecera = new Table(pointColumnWidths);
                tablaCabecera.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(image.ScaleAbsolute(70, 70)));
                tablaCabecera.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(datosEmpresa));
                tablaCabecera.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                tablaCabecera.AddCell(new Cell().SetBorder(Border.NO_BORDER).Add(datosFactura));

                //Cuerpo del PDF (datos del cliente)
                Table tablaCliente = new Table(1).UseAllAvailableWidth();
                tablaCliente.AddCell(new Cell().Add(datosCliente).SetPadding(7).SetBorder(Border.NO_BORDER));

                //Cuerpo del PDF(articulos de la venta)
                Color bgColour = new DeviceRgb(240, 240, 240);
                float[] pointColumnWidths2 = { 10F, 150F, 10F, 90F, 50F };
                Table tablaArticulosVenta = new Table(pointColumnWidths2).UseAllAvailableWidth();
                tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph("#")).SetBackgroundColor(bgColour).SetBorder(Border.NO_BORDER).SetPadding(2).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph("Descripción")).SetBackgroundColor(bgColour).SetBorder(Border.NO_BORDER).SetPadding(2).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph("Cantidad")).SetBackgroundColor(bgColour).SetBorder(Border.NO_BORDER).SetPadding(2).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph("Precio Unitario")).SetBackgroundColor(bgColour).SetBorder(Border.NO_BORDER).SetPadding(2).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph("SubTotal")).SetBackgroundColor(bgColour).SetBorder(Border.NO_BORDER).SetPadding(2).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                var itt = Productos;
                int indice = 1;
                foreach (var item in itt)
                {
                    tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph(indice.ToString())).SetBorder(Border.NO_BORDER).SetPadding(2).SetFontSize(10).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph(item.NombreProducto).SetMarginLeft(10)).SetBorder(Border.NO_BORDER).SetFontSize(10).SetPadding(2));
                    tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph(item.Cantidad.ToString())).SetPadding(2).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph(item.Precio.ToString("0.00"))).SetPadding(2).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    tablaArticulosVenta.AddCell(new Cell().Add(new Paragraph((item.Cantidad * item.Precio).ToString("0.00"))).SetPadding(2).SetBorder(Border.NO_BORDER).SetFontSize(10).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));
                    indice++;
                }


                //Total de la venta en valor numerico y texto
                string totalNumeroALetras = NumeroALetras(eMovimientoCompleja.PrecioTotal);
                Paragraph total = new Paragraph("TOTAL EN BOLIVIANOS: " + eMovimientoCompleja.PrecioTotal.ToString("0.00") + "\n\nSon: " + totalNumeroALetras).SetBackgroundColor(bgColour).SetFontSize(11).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
                
                //Pie del PDF (codigo de control y otros textos)
                string dataQR = "395410026|" + eMovimientoCompleja.NroMovimiento + "|" + eDosificacionCompleja.NroAutorizacion + "|" + eMovimientoCompleja.FechaRegistro.ToString("dd/MM/yyyy") + "|" + eMovimientoCompleja.PrecioTotal.ToString("0.00") + "|" + eMovimientoCompleja.PrecioTotal.ToString("0.00") + "|" + eMovimientoCompleja.CodigoControl + "|" + eMovimientoCompleja.NitCi + "|0|0|0|0";
                byte[] qr = generaQR(dataQR);
                ImageData imageDataQR = ImageDataFactory.Create(qr);
                Image imageQR = new Image(imageDataQR).ScaleToFit(80f, 80f);

                Table tablaPie = new Table(2).UseAllAvailableWidth();
                tablaPie.AddCell(new Cell().Add(imageQR)).SetPadding(2);
                tablaPie.AddCell(new Cell().Add(new Paragraph("\"ESTA FACTURA CONTRIBUYE AL DESARROLLO DEL PAÍS, EL USO ÍLICITO DE ÉSTA SERÁ SANCIONADO DE ACUERDO A LA LEY\"\n" +
                                                              "Ley N° 453: Tienes derecho a un trato equitativo sin discriminación en la oferta de servicios").SetFontSize(11).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)));

                //Contruccion del PDF
                document.Add(tablaCabecera);
                document.Add(tituloFactura);
                document.Add(tablaCliente);
                document.Add(saltoLinea);
                document.Add(tablaArticulosVenta);
                document.Add(saltoLinea);
                document.Add(total);
                document.Add(saltoLinea);
                document.Add(codigoControl);
                document.Add(tablaPie);

                document.Close();

                return stream.ToArray();
            }
        }

        /// <summary>
        /// Metodo que genera el QR recibiendo la data a convertir
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna el QR en arreglo de bytes</returns>
        public byte[] generaQR(string data)
        {
            //Instancia de los objetos a utilizar para crear el QR
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qRCode.GetGraphic(20);
            return qrCodeBytes;
        }

        /// <summary>
        /// Metodo que retorna un valor numerico en formato de texto
        /// </summary>
        /// <param name="numberAsString"></param>
        /// <returns>Retorna la cadena de texto del valor numerico</returns>
        public string NumeroALetras(decimal numberAsString)
        {
            var entero = Convert.ToInt64(Math.Truncate(numberAsString));
            var decimales = Convert.ToInt32(Math.Round((numberAsString - entero) * 100, 2));
            string dec = (decimales > 0) ? $" BOLIVIANOS {decimales:0,0} /100" : $" BOLIVIANOS {decimales:0,0} /100";
            var res = NumeroALetras(Convert.ToDouble(entero)) + dec;
            return res;
        }

        /// <summary>
        /// Metodo que evalua el numero que recibe para convertirlo a texto
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Retorna el valor numerico en formato textual</returns>
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
