using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public  class EMovimiento
    {
        public string Codigo { get; set; }
        public int Cont { get; set; }
        public string Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCliente { get; set; }
        public int IdMovimiento { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCliente { get; set; }
        public string NombreUsuario { get; set; }
        public string TipoMovimiento { get; set; }

        public decimal PrecioTotal { get; set; }
        public int? IdDosificacion { get; set; }
        public int? NroMovimiento { get; set; }
        public string CodigoControl { get; set; }
        public string RazonSocial { get; set; }
        public string NitCi { get; set; }
    }
}
