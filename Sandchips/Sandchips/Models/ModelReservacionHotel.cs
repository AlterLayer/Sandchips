using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandchips.Models
{
    public class ModelReservacionHotel
    {
        public int IdReservacionHotel { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public int IdClientes { get; set; }
        public string Clientes { get; set; }
        public double Precio { get; set; }
        public int IdHabitaciones { get; set; }
        public string Habitaciones { get; set; }
        public int IdDetalleLocal { get; set; }
        public string DetalleLocal { get; set; }
        public int IdEstadoReservacion { get; set; }
        public string EstadoReservacion { get; set; }
    }
}
