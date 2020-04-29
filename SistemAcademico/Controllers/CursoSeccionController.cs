using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemAcademico.Filters;
using SistemAcademico.Models;

namespace SistemAcademico.Controllers
{
    [Acceder]
    public class CursoSeccionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MantenimientoCursoSeccion()
        {
            HttpContext.Session.GetString("Usuario");
            HttpContext.Session.GetString("Menu");
            //HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            return View("MantenimientoCursoSeccion", Code.Curso.ConsultarCursoSeccion());
        }

        public IActionResult AgregarCursoSeccion()
        {
            HttpContext.Session.GetString("Usuario");
            HttpContext.Session.GetString("Menu");
            //HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            ViewBag.Curso = Code.Curso.ConsultarCatalogoCurso();
            ViewBag.Seccion = Code.Seccion.ConsultarCatalogoSeccion();
            return PartialView("AgregarCursoSeccion");
        }

        public IActionResult GrabarCursoSeccion(CursoSeccionModel model)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            Code.Seccion.GrabarCursoSeccion(model);
            return PartialView("Index");
        }
    }
}