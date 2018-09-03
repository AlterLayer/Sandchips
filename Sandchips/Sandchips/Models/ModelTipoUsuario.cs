using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandchips.Models
{
    public class ModelTipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string TipoUsuarioP { get; set; }
    }

    public static class ModelPermiso
    {
        public static string TipoUsuarioP { get; set; }
    }

}
