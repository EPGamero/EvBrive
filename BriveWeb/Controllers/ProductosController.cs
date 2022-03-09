using Microsoft.AspNetCore.Mvc;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BriveWeb.Controllers
{
    public class ProductosController : System.Web.Mvc.Controller
    {
        public IActionResult Index()
        {
            return (IActionResult)View();
        }
        public System.Web.Mvc.JsonResult GetAll()
        {
            return Json(Negocio.Producto.GetAll().Datos, JsonRequestBehavior.AllowGet);
        }

        public System.Web.Mvc.JsonResult GetById(Productos producto)
        {
            var request = Negocio.Producto.GetById(producto).Datos.FirstOrDefault();
            return Json(request, JsonRequestBehavior.AllowGet);
        }

        public System.Web.Mvc.JsonResult Add(Productos producto)
        {
            var request = Negocio.Producto.Add(producto);
            return Json(request, JsonRequestBehavior.AllowGet);
        }

        public System.Web.Mvc.JsonResult Update(Productos producto)
        {
            var request = Negocio.Producto.Update(producto);
            return Json(request, JsonRequestBehavior.AllowGet);
        }

        public System.Web.Mvc.JsonResult Delete(Productos producto)
        {
            var request = Negocio.Producto.Delete(producto);
            return Json(request, JsonRequestBehavior.AllowGet);
        }
    }
}
