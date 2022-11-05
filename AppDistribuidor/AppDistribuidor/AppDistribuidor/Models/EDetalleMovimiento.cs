using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public class EDetalleMovimiento
    {
        public byte Cantidad { get; set; }
        public int Cont { get; set; }
        public string Estado { get; set; }
        public int IdDetalleMovimiento { get; set; }     
        public int IdMovimiento { get; set; }     
        public int IdProducto { get; set; }            
        public decimal PrecioUnitario { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }

        public decimal SubTotal { get; set; }

    }
}
