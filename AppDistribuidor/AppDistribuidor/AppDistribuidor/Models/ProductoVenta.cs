using System;

namespace AppDistribuidor.Models
{
    public class ProductoVenta
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }

        public byte Cantidad { get; set; }
 
  
    }
}
