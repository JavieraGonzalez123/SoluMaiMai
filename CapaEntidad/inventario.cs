using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Inventario
    {
    public int IdInventario { get; set; }
    public Insumos oInsumos { get; set; }
    public int Stock { get; set; }
    public DateTime FechaRegistro { get; set; }
    }
}
