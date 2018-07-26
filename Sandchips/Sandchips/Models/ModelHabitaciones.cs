using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandchips.Models
{
    public class ModelHabitaciones
    {
        public int IdHabitacion { get; set; }
        public int NumeroHabitacion { get; set; } 
        public string TipoHabitacion { get; set; }
        public int IdTipoHabitacion { get; set; }
        public string Estado { get; set; }
        public int IdEstado { get; set; } 
    }
}
