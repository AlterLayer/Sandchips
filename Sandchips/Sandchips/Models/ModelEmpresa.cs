using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandchips.Models
{
    public class ModelEmpresa
    {
        public int IdEmpresa { get; set; } 
        public string Empresa { get; set; }
        public string NRC { get; set; }
        public string NIT { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int IdTipoEmpresa { get; set; }
        public string RegistroIVA { get; set; }
        public string RegistroAuditor { get; set; }
    }
}
