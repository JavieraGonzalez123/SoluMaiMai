using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProductoInsumos
    {
    public int IdProductoInsumos { get; set; }
    public Producto oProducto { get; set; }
    public Insumos oInsumos { get; set; }
    public Decimal CantidadRequerida { get; set; }
    }
}
