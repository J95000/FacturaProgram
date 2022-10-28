using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public  class ProductoPrestamo
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }

        public byte Cantidad { get; set; }
    }
}
