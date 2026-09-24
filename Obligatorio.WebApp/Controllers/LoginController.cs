using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios;
using Obligatorio.LogicaAplicacion.DTO;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private LoginUsuario _login;

        public LoginController(LoginUsuario login)
        {
            _login = login;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DtoLogin dto)
        {
            try
            {
                Usuario usuario = _login.Ejecutar(dto);

                HttpContext.Session.SetString(
                    "NombreUsuario",
                    usuario.NombreUsuario
                );

                HttpContext.Session.SetString(
                    "Rol",
                    usuario.Rol.Valor
                );

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(dto);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}