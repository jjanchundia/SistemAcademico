using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemAcademico.Filters;
using SistemAcademico.Models;

namespace SistemAcademico.Controllers
{
    [Acceder]
    public class ProfesorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MantenimientoProfesor()
        {
            HttpContext.Session.GetString("Usuario");
            HttpContext.Session.GetString("Menu");
            //HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            return View("MantenimientoProfesor", Code.Profesor.ConsultarProfesores(null, null));
        }

        public IActionResult GrabarProfesor(ProfesorModel model)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            Code.Profesor.GrabarProfesor(model);
            return View("Index");
        }

        public IActionResult AgregarProfesor()
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            return PartialView("AgregarProfesor");
        }

        public IActionResult EditarProfesor(int idProfesor)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            var x = Code.Profesor.ConsultarProfesorPorId(idProfesor);
            return PartialView("EditarProfesor", x);
        }

        public IActionResult ActualizarProfesor(ProfesorModel model)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            Code.Profesor.ActualizarProfesor(model);
            return MantenimientoProfesor();
        }

        public void EliminarProfesor(int idProfesor)
        {
            HttpContext.Session.GetString("Usuario");
            //var menu = HttpContext.Session.GetString("Menu");
            //var sesionMenu = JsonConvert.DeserializeObject<List<MenuModel>>(menu);
            //ViewBag.Menu = sesionMenu;
            Code.Profesor.EliminarProfesor(idProfesor);
        }
    }
}