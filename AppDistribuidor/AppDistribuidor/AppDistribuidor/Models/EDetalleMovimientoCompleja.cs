using System;

namespace AppDistribuidor.Models
{
    public class EDetalleMovimientoCompleja
    {
        public int IdDetalleMovimiento { get; set; }
        public int IdMovimiento { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public byte Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Estado { get; set; }
        public decimal SubTotal { get; set; }
        public int Cont { get; set; }
        public string NombreProducto { get; set; }

        public EDetalleMovimientoCompleja()
        {
            IdDetalleMovimiento = 0;
            IdMovimiento = 0;
            IdProducto = 0;
            PrecioUnitario = 0;
            Cantidad = 0;
            FechaRegistro = DateTime.Now;
            FechaModificacion = DateTime.Now;
            Estado = string.Empty;
            SubTotal = 0;
        }
    }
}
