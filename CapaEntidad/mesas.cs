using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Mesas
    {
        public int IdMesas { get; set; }
        public int NumeroMesa { get; set; }
        public int Capacidad { get; set; }
        public EstadoMesas oEstadoMesas { get; set; }

    }
}
