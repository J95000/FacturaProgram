using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public class ECategoriaCliente
    {
        public int Cont { get; set; }
        public string Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCategoriaCliente { get; set; }
        public string NombreCategoriaCliente { get; set; }
    }
}
