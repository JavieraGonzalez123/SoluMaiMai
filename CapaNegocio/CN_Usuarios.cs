﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objCapaDato = new CD_Usuarios();

        public List<Usuario> Listar()
        {
            return objCapaDato.Listar();
        }
        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre de usuario no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El apellido de usuario no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del usuario no puede estar vacio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = CN_Recursos.GenerarClave();
                string asunto = "Creacion de Cuenta";
                string mensaje_correo = "<h3>Su cuenta fue creada exitosamente</h3><p> Su contraseña para acceder es: !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!",clave);

                bool respuesta = CN_Recursos.EnviarCorreo(obj.Correo, asunto, mensaje_correo);
                if (respuesta)
                {
                   obj.Clave = CN_Recursos.ConvertirSha256(clave);
                   return objCapaDato.Registrar(obj, out Mensaje);

                }
                else
                {
                    Mensaje = "No se puede enviar el correo ";
                    return 0;
                }


                

                
            }
            else
            {
                return 0;
            }
            

        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrEmpty(obj.Nombre))
            {
                Mensaje = "El nombre de usuario no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrEmpty(obj.Apellidos))
            {

                Mensaje = "El apellido de usuario no puede estar vacio";
            } 
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrEmpty(obj.Correo))
            {
                Mensaje = "El correo del usuario no puede estar vacio";
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
