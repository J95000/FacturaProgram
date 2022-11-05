using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public class EDosificacionCompleja
    {
        public int IdDosificacion { get; set; }
        public string NroAutorizacion { get; set; }
        public DateTime FechaLimite { get; set; }
        public string LlaveDosificacion { get; set; }
        public int NroInicialFactura { get; set; }
        public int NroFinalFactura { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Estado { get; set; }
    }
}
