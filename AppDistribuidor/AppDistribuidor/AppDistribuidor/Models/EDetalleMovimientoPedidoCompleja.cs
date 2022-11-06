using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public class EDetalleMovimientoPedidoCompleja
    {
        public int Cantidad { get; set; }
        public int IdDetalleMovimiento { get; set; }
        public int IdMovimiento { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioUnitario { get; set; }
        public double SubTotal { get; set; }
    }
}
