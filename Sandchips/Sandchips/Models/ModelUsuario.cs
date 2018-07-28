using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandchips.Models
{
   public class ModelUsuario
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Nacimiento { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdGenero { get; set; }
        public int IdEstado { get; set; }
        public int IdTipoUsuarios { get; set; }
    }
}
