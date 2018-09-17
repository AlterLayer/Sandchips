using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandchips.Models
{
    class ModelReservacionRestaurante
    {
        public int IdReservacionRestaurante { get; set; }
        public string FechaHoraIngreso { get; set; }
        public int NumeroPersonas { get; set; }
        public int IdCliente { get; set; }
        public int IdEstadoRestaurante { get; set; }
        public int IdRestaurante { get; set; }
        public ModelReservacionRestaurante() { }
    }
}
