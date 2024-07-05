using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Insumos
    {
        
            private CD_Insumos objCapaDato = new CD_Insumos();

            public List<Insumos> Listar()
            {
                return objCapaDato.Listar();
            }
            public int Registrar(Insumos obj, out string Mensaje)
            {
                Mensaje = string.Empty;

                if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
                {
                    Mensaje = "El nombre del insumo no puede estar vacio";
                }
                else if (string.IsNullOrEmpty(obj.UnidadMedida) || string.IsNullOrWhiteSpace(obj.UnidadMedida))
                {
                    Mensaje = "La Unidad de medida de la categoria no puede estar vacia";
                }



                if (string.IsNullOrEmpty(Mensaje))
                {

                    return objCapaDato.Registrar(obj, out Mensaje);

                }
                else
                {
                    return 0;
                }

            }
            public bool Editar(Insumos obj, out string Mensaje)
            {
                Mensaje = string.Empty;

                if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrEmpty(obj.Nombre))
                {
                    Mensaje = "El nombre del insumo no puede estar vacio";
                }
                else if (string.IsNullOrEmpty(obj.UnidadMedida) || string.IsNullOrEmpty(obj.UnidadMedida))
                {

                    Mensaje = "La Unidad de medida no puede estar vacia";
                }



                if (string.IsNullOrEmpty(Mensaje))
                {
                    return objCapaDato.Editar(obj, out Mensaje);
                }
                else
                {
                    return false;
                }
            }
            public bool Eliminar(int id, out string Mensaje)
            {
                return objCapaDato.Eliminar(id, out Mensaje);
            }
        }
    
}
