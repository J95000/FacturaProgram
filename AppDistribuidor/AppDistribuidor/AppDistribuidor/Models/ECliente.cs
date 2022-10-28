using System;
using System.Collections.Generic;
using System.Text;

namespace AppDistribuidor.Models
{
    public class ECliente
    {
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Telefono { get; set; }
        public int Cont { get; set; }
        public bool Contrato { get; set; }
        public string CorreoElectronico { get; set; }
        public byte[] FotoUbicacion { get; set; }
        public int IdCategoriaCliente { get; set; }
        public int IdCliente { get; set; }
        public int IdZona { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string NombreCategoriaCliente { get; set; }
        public string NombreZona { get; set; }
    }
}
