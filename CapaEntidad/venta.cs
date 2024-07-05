using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Usuario oUsuario { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal MontoTotal { get; set; }
        public int TotalProducto { get; set; }
        public string Telefono { get; set; }


 


    }
}
