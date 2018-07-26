using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandchips.Models
{
   public class ModelUsuario
    {
        public int Id_Usuario { get; set; }
        public int Id_Persona { get; set; }
        public string Usuario { get; set; }
        public string password { get; set; }
        public int estado { get; set; }
        public string Estado { get; set; }
        public string Persona { get; set; }
        public int Tipo_Usuario { get; set; }
    }
}
