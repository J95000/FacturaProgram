using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public class ETipoGasto
    {
        public int Cont { get; set; }
        public string Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public byte IdTipoGasto { get; set; }
        public string NombreTipoGasto { get; set; }
        public string Tipo { get; set; }
    }
}
