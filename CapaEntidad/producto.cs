using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
    public int IdProducto { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public string PrecioTexto { get; set; }
    public Categoria oCategorias { get; set; }
    public bool Activo { get; set; }
    public Proveedor oProveedor { get; set; }

    }
}
