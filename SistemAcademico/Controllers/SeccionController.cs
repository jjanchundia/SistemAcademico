using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemAcademico.Filters;
using SistemAcademico.Models;
using System.Collections.Generic;

namespace SistemAcademico.Controllers
{
    [Acceder]
    public class SeccionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MantenimientoSeccion()
        {
            HttpContext.Session.GetString("Usuario");
            HttpContext.Session.GetString("Menu");
            //HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            return View("MantenimientoSeccion", Code.Seccion.ConsultarSeccion(null));
        }

        public IActionResult GrabarSeccion(SeccionModel model)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            Code.Seccion.GrabarSeccion(model);
            return PartialView("Index");
        }

        public IActionResult AgregarSeccion()
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            ViewBag.Profesor = Code.Profesor.ConsultarCatalogoProfesor();
            ViewBag.Curso = Code.Curso.ConsultarCatalogoCurso();
            return PartialView("AgregarSeccion");
        }

        public IActionResult EditarSeccion(int idSeccion)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            var seccion = Code.Seccion.ConsultarSeccionPorId(idSeccion);
            ViewBag.Profesor = Code.Profesor.ConsultarCatalogoProfesor();
            ViewBag.Curso = Code.Curso.ConsultarCatalogoCurso();
            return PartialView("EditarSeccion", seccion);
        }

        public IActionResult ActualizarSeccion(SeccionModel model)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            Code.Seccion.ActualizarSeccion(model);
            return MantenimientoSeccion();
        }

        public void EliminarSeccion(int idSeccion)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            Code.Seccion.EliminarSeccion(idSeccion);
        }
    }
}