using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandchips.Models
{
    public class ModelClientes
    {
        public int IdClientes { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public int IdGenero { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoDocumento { get; set; }
    }
}
