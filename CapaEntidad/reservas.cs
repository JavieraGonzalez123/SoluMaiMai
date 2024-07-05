using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Reservas
    {
        public int IdReservas { get; set; }
        public Mesas oMesas { get; set; }
        public Usuario oUsuario { get; set; }
        public DateTime FechaReserva { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }

    }
}
