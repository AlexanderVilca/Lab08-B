using MVCDEMO10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDEMO10.Controllers
{
    public class ProductoController : Controller
    {

        List<Producto> productos = new List<Producto>();
        // GET: Producto
        public ActionResult Index()
        {
            if (Session["productos"] == null)
                Session["productos"] = productos;
            else
                productos = (List<Producto>)Session["productos"];


            return View(productos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View( new Producto());
        }

        [HttpPost]
        public ActionResult Create(Producto producto)
        {

            ((List<Producto>)Session["productos"]).Add(producto);

            return RedirectToAction("Index");
        }

        [HttpPut]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return View();
        }
    }
}