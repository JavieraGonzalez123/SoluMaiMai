using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetallePedidos
    {
    public int IdDetallePedidos { get; set; }
    public Pedidos oPedidos { get; set; }
    public Insumos oInsumos { get; set; }
    public int Cantidad { get; set; }
    public Decimal PrecioUnitario { get; set; }
    }
}
