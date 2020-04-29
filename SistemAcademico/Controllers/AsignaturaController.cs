using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemAcademico.Filters;
using SistemAcademico.Models;
using System.Collections.Generic;

namespace SistemAcademico.Controllers
{
    [Acceder]
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MantenimientoAsignatura()
        {
            HttpContext.Session.GetString("Usuario");
            HttpContext.Session.GetString("Menu");
            //HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            return View("MantenimientoAsignatura", Code.Asignatura.ConsultarAsignatura(null));
        }

        public IActionResult AgregarAsignatura()
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            ViewBag.Profesor = Code.Profesor.ConsultarCatalogoProfesor();
            ViewBag.Curso = Code.Curso.ConsultarCatalogoCurso();
            return PartialView("AgregarAsignatura");
        }

        public IActionResult GrabarAsignatura(AsignaturaModel model)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            Code.Asignatura.GrabarAsignatura(model);
            return View("Index");
        }

        public IActionResult EditarAsignatura(int idAsignatura)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            var asignatura = Code.Asignatura.ConsultarAsignaturaPorId(idAsignatura);
            ViewBag.Profesor = Code.Profesor.ConsultarCatalogoProfesor();
            ViewBag.Curso = Code.Curso.ConsultarCatalogoCurso();
            return PartialView("EditarAsignatura", asignatura);
        }

        public IActionResult ActualizarAsignatura(AsignaturaModel model)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            Code.Asignatura.ActualizarAsignatura(model);
            return View();
        }

        public IActionResult EliminarAsignatura(int idAsignatura)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            Code.Asignatura.EliminarAsignatura(idAsignatura);
            return MantenimientoAsignatura();
        }
    }
}