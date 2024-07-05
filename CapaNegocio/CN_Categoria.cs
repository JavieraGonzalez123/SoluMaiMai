using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objCapaDato = new CD_Categoria();

        public List<Categoria> Listar()
        {
            return objCapaDato.Listar();
        }
        public int Registrar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre de la categoria no puede estar vacia";
            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion de la categoria no puede estar vacia";
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
        public bool Editar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrEmpty(obj.Nombre))
            {
                Mensaje = "El nombre de la categoria no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrEmpty(obj.Descripcion))
            {

                Mensaje = "La descripcion no puede estar vacia";
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
