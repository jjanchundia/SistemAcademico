using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemAcademico.Filters;
using SistemAcademico.Models;

namespace SistemAcademico.Controllers
{
    [Acceder]
    public class CalificacionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calificaciones()
        {
            HttpContext.Session.GetString("Usuario");
            HttpContext.Session.GetString("Menu");
            
            ViewBag.CursoSeccion = Code.Curso.ConsultarCatalogoCursoSeccion();
            ViewBag.Asignatura = Code.Asignatura.ConsultarCatalogoAsignatura();
            return View("Calificaciones", new CalificacionesModel());
        }

        public IActionResult ConsultarCalificaciones(int idPeriodo, int idCursoSeccion, int idAsignatura)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            var calificaciones = Code.Calificacion.ConsultarCalificacion(idPeriodo, idCursoSeccion, idAsignatura);
            return View("ListaCalificaciones", calificaciones);
        }

        public IActionResult GrabarCalificacion()
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;

            return View();
        }

    }
}