using Microsoft.AspNetCore.Mvc;
using SistemAcademico.Filters;
using SistemAcademico.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SistemAcademico.Controllers
{
    [Acceder]
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MantenimientoAlumno()
        {
            HttpContext.Session.GetString("Usuario");
            HttpContext.Session.GetString("Menu");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            return View("MantenimientoAlumno", Code.Alumno.ConsultarAlumnos(null));
        }

        public IActionResult AgregarAlumno()
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            ViewBag.CursoSeccion = Code.Curso.ConsultarCatalogoCursoSeccion();
            return PartialView();
        }

        public IActionResult GrabarAlumno(AlumnoModel model)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            Code.Alumno.GrabarALumno(model);
            return View("Index");
        }

        public IActionResult EditarAlumno(int idAlumno)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            var x = Code.Alumno.ConsultarAlumnosPorId(idAlumno);
            return PartialView("EditarAlumno", x);
        }

        public IActionResult ActualizarAlumno(AlumnoModel model)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            Code.Alumno.ActualizarAlumno(model);
            return MantenimientoAlumno();
        }

        public void EliminarAlumno(int idAlumno)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            Code.Alumno.EliminarAlumno(idAlumno);
        }
    }
}