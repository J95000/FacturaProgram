using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public  class EPrecioSugerido
    {
        public int Cont { get; set; }
        public string Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdPrecioSugerido { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }


    }
}
