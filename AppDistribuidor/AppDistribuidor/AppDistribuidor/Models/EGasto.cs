using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public class EGasto
    {
        public int Cantidad { get; set; }
        public int Cont { get; set; }
        public string Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdAprovador { get; set; }
        public int IdGasto { get; set; }
        public int IdTipoGasto { get; set; }
        public int IdUsuario { get; set; }
        public string NombreTipoGasto { get; set; }
        public decimal Precio { get; set; }
    }
}
