    using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace AppDistribuidor.Facturacion
{
    public class EnvioCorreo
    {
        /// <summary>
        /// Metodo que realiza el envio de correos mediante GMAIL
        /// </summary>
        /// <param name="emisor">Emisor del Correo</param>
        /// <param name="receptor">Receptor del Correo</param>
        /// <param name="document">PDF que se adjuntará al Correo</param>
        public void EnviarCorreo(string emisor, string receptor, byte[] document)
        {
            //Declaramos las instancias a utilizar para la generacion del correo
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
            SmtpServer.Credentials = new System.Net.NetworkCredential(emisor, "nrcvynqcxyzvycfl");

            SmtpServer.Send(mail);
        }
    }
}
