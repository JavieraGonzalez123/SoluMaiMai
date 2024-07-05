using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pedidos
    {
    public int IdPedidos { get; set; }
    public Proveedor oProveedor { get; set; }
    public DateTime FechaPedido { get; set; }
    public string Estado { get; set; }
    }
}
