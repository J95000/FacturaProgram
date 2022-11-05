using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public class EClienteCompleja
    {
        public string Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Telefono { get; set; }
        public int Cont { get; set; }
        public string CorreoElectronico { get; set; }
        public byte[] FotoUbicacion { get; set; }
        public int IdCliente { get; set; }

        public string RazonSocial { get; set; }

        public string NitCi { get; set; }
        public string Direccion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
    }
}
