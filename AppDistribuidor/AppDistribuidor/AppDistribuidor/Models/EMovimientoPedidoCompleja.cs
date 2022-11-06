using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public  class EMovimientoPedidoCompleja
    {
        public string Codigo { get; set; }
        public int Cont { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public byte[] FotoUbicacion { get; set; }
        public int IdCliente { get; set; }
        public int IdDireccion { get; set; }
        public int IdMovimiento { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string NitCi { get; set; }
        public string NombreCliente { get; set; }
        public string NombreDireccion { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }

    }
}
