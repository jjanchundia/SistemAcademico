using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Newtonsoft.Json;
using SistemAcademico.Models;
using System.Collections.Generic;

namespace SistemAcademico.Controllers
{
    public class LoginController : Controller
    {        
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult IngresarLogin(string usuario, string password)
        {
            var login = Code.Usuario.ConsultarUsuario(usuario, password);

            if (login.Count() > 0)
            {
                HttpContext.Session.SetString("Usuario", login.FirstOrDefault().Usuario);
                var listaMenu = Code.Usuario.ConsultarMenu(login.FirstOrDefault().IdRol);

                HttpContext.Session.SetString("Menu", JsonConvert.SerializeObject(listaMenu));

                JsonConvert.DeserializeObject<List<MenuModel>>(HttpContext.Session.GetString("Menu"));

                HttpContext.Session.GetString("Usuario");
                HttpContext.Session.GetString("Menu");
                //ViewBag.Menu = sesionMenu;

                return View("../Home/Index", listaMenu);
            }

            return View("Login");
        }
    }
}