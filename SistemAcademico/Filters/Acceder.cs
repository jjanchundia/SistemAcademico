using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SistemAcademico.Filters
{
    public class Acceder:ActionFilterAttribute
    {
        public HttpContext context;
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //Si session es nulo, retorna al login
            var usuario = context.HttpContext.Session.GetString("Usuario");
            context.HttpContext.Session.GetString("Menu");

            if (usuario == null)
            {
                context.Result = new RedirectResult("~/Login/Login");
            }

            base.OnActionExecuted(context);
        }
    }
}
