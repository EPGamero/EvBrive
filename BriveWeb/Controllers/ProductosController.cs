using Microsoft.AspNetCore.Mvc;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BriveWeb.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            return (IActionResult)View();
        }
        public JsonResult GetAll()
        {
            return Json(Negocio.Producto.GetAll().Datos);
        }

        public JsonResult GetById(Productos producto)
        {
            var request = Negocio.Producto.GetById(producto).Datos.FirstOrDefault();
            return Json(request);
        }

        public JsonResult Add(Productos producto)
        {
            var request = Negocio.Producto.Add(producto);
            return Json(request);
        }

        public JsonResult Update(Productos producto)
        {
            var request = Negocio.Producto.Update(producto);
            return Json(request);
        }

        public JsonResult Delete(Productos producto)
        {
            var request = Negocio.Producto.Delete(producto);
            return Json(request);
        }
    }
}
