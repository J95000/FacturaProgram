using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public class EUsuario
    {
        public string Contrasena { get; set; }
        public string Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdUsuario { get; set; }
        public string NombreTipoUsuario { get; set; }
    }
}
