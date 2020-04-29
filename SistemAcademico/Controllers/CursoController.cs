using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemAcademico.Filters;
using SistemAcademico.Models;
using System.Collections.Generic;

namespace SistemAcademico.Controllers
{
    [Acceder]
    public class CursoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MantenimientoCurso()
        {
            HttpContext.Session.GetString("Usuario");
            HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            return View("MantenimientoCurso", Code.Curso.ConsultarCurso(null));
        }

        public IActionResult AgregarCurso()
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            ViewBag.Profesor = Code.Profesor.ConsultarCatalogoProfesor();
            return PartialView("AgregarCurso");
        }

        public IActionResult GrabarCurso(CursoModel model)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            Code.Curso.GrabarCurso(model);
            return View("Index");
        }

        public IActionResult EditarCurso(int idCurso)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            var curso = Code.Curso.ConsultarCursoPorId(idCurso);
            ViewBag.Profesor = Code.Profesor.ConsultarCatalogoProfesor();
            return PartialView("EditarCurso", curso);
        }

        public IActionResult ActualizarCurso(CursoModel model)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            Code.Curso.ActualizarCurso(model);
            return MantenimientoCurso();
        }

        public void EliminarCurso(int idCurso)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            Code.Curso.EliminarCurso(idCurso);
        }
    }
}