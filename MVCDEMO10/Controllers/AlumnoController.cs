using MVCDEMO10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDEMO10.Controllers
{
    public class AlumnoController : Controller
    {

        List<Alumno> alumnos = new List<Alumno>();
        // GET: Alumno
        public ActionResult Index()
        {
            if (Session["alumnos"] == null)
                Session["alumnos"] = alumnos;
            else
                alumnos = (List<Alumno>)Session["alumnos"];


            return View(alumnos);
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View(new Alumno());
        }

        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {

            alumnos = (List<Alumno>)Session["alumnos"];

            if (alumnos.Count > 0)
                alumno.AlumnoID = alumnos.Max(a => a.AlumnoID) + 1;
            else
                alumno.AlumnoID = 1; 

            alumnos.Add(alumno);
            Session["alumnos"] = alumnos;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            alumnos = (List<Alumno>)Session["alumnos"];
            Alumno alumno = alumnos.FirstOrDefault(a => a.AlumnoID == id);
            if (alumno == null)
                return HttpNotFound();

            return View(alumno);
        }

        [HttpPost]
        public ActionResult Edit(Alumno alumno)
        {
            alumnos = (List<Alumno>)Session["alumnos"];
            Alumno existingAlumno = alumnos.FirstOrDefault(a => a.AlumnoID == alumno.AlumnoID);

            if (existingAlumno != null)
            {
                existingAlumno.Nombre = alumno.Nombre;
                existingAlumno.Apellidos = alumno.Apellidos;
                existingAlumno.Grado = alumno.Grado;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            alumnos = (List<Alumno>)Session["alumnos"];
            Alumno alumno = alumnos.FirstOrDefault(a => a.AlumnoID == id);
            if (alumno == null)
                return HttpNotFound();

            return View(alumno);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            alumnos = (List<Alumno>)Session["alumnos"];
            Alumno alumno = alumnos.FirstOrDefault(a => a.AlumnoID == id);
            if (alumno != null)
            {
                alumnos.Remove(alumno);
            }

            return RedirectToAction("Index");
        }
    }
}