using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppDistribuidor
{
    public static class VariablesGlobales
    {
        public static int IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }
        public static int Conta { get; set; }

        public static string Contrasena { get; set; }
        public static Stream stream { get; set; }


        public static int Bandera { get; set; }
        public static decimal Total { get; set; }
        public static decimal TotalPrestamo { get; set; }
        public static byte idTipoGasto { get; set; }


        public static byte TipoRegistroCliente = 0;
        public static string NombreClienteRegistrado = "";

    }
}
