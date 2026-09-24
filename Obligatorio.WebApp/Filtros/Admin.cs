using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.WebApp.Filtros
{
    public class Admin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Rol") != "Administrador")
            {
                context.Result =
                    new RedirectToActionResult("Index", "Login", null);
            }
        }
    }
}