using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public  class EUbicacion
    {

        public int IdUsuario { get; set; }
        public string NombreDispositivo { get; set; }
        public decimal Latitud { get; set; }

        public decimal Longitud { get; set; }

        public DateTime Fecha { get; set; }
    }
}
