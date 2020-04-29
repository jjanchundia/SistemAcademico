using Microsoft.AspNetCore.Mvc;
using SistemAcademico.Models;

namespace SistemAcademico.Controllers
{
    public class AdminController : Controller
    {      
        public IActionResult Index()
        {
            return View();
        }       
    }
}