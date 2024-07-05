using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeteriaMaiMaiAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor

        public ActionResult Categoria()
        {
            return View();
        }
        public ActionResult Productos()
        {
            return View();
        }

        public ActionResult Insumos()
        {
            return View();
        }

        public ActionResult Pedidos()
        {
            return View();
        }

        public ActionResult Mesas()
        {
            return View();
        }

        public ActionResult Reservas()
        {
            return View();
        }

        //CATEGORIA//

        #region CATEGORIA
        [HttpGet]
        public JsonResult ListarCategoria()
        {
            List<Categoria> oLista = new List<Categoria>();
            oLista = new CN_Categoria().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarCategoria(Categoria objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdCategoria == 0)
            {
                resultado = new CN_Categoria().Registrar(objeto, out mensaje);

            }
            else
            {
                resultado = new CN_Categoria().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Categoria().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion CATEGORIA


        //INSUMOS
        #region INSUMOS
        [HttpGet]
        public JsonResult ListarInsumos()
        {
            List<Insumos> oLista = new List<Insumos>();
            oLista = new CN_Insumos().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarInsumos(Insumos objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdInsumos == 0)
            {
                resultado = new CN_Insumos().Registrar(objeto, out mensaje);

            }
            else
            {
                resultado = new CN_Insumos().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarInsumos(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Insumos().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion INSUMOS



        //PRODUCTO
        #region PRODUCTO
        [HttpGet]
        public JsonResult ListarProducto()
        {
            List<Producto> oLista = new List<Producto>();
            oLista = new CN_Productos().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarProducto(string objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            bool operacion_exitosa = true;
            
            Producto oProducto =new Producto();
            oProducto =JsonConvert.DeserializeObject<Producto>(objeto);

            decimal precio;
            if (decimal.TryParse(oProducto.PrecioTexto,NumberStyles.AllowDecimalPoint,new CultureInfo("es-CL"),out precio))
            {
                oProducto.Precio = precio;


            }
            else
            {
                return Json(new { operacion_exitosa = false, mensaje = "El formato del precio debe ser ##.###" }, JsonRequestBehavior.AllowGet);
            }



            if (oProducto.IdProducto == 0)
            {
                int idProductoGenerado = new CN_Productos().Registrar(oProducto, out mensaje);
                if(idProductoGenerado != 0)
                {
                    oProducto.IdProducto = idProductoGenerado;
                }
                else
                {
                    operacion_exitosa=false;
                }
            }
            else
            {
                operacion_exitosa = new CN_Productos().Editar(oProducto, out mensaje);
            }


            return Json(new { operacion_exitosa = operacion_exitosa, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarProducto(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Productos().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

#endregion PRODUCTO
    }


}

   

