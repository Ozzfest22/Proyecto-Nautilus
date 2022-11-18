using ProyectoTest.Logica;
using ProyectoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTest.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ReporteVentas() 
        {
            List<ReporteVenta> listaVentas = new List<ReporteVenta>();

            listaVentas = ReporteLogica.Instancia.GraficoVentas();

            return Json(listaVentas, JsonRequestBehavior.AllowGet);   
        }

        [HttpGet]
        public JsonResult ReporteProductos()
        {
            List<ReporteProducto> listaProductos = new List<ReporteProducto>();

            listaProductos = ReporteLogica.Instancia.GraficoProductos();

            return Json(listaProductos, JsonRequestBehavior.AllowGet);
        }
    }   
}