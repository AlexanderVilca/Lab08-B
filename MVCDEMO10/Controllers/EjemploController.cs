using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDEMO10.Controllers
{
    public class EjemploController : Controller
    {
        // GET: Ejemplo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Direccion()
        {
            return View();
        }

        public ActionResult DatosPersonales()
        {
            return View();
        }
    }
}