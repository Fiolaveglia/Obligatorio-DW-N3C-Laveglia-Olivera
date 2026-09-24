using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.CasosDeUso.Usuarios;
using Obligatorio.LogicaAplicacion.DTO;
using Obligatorio.WebApp.Filtros;

namespace Obligatorio.WebApp.Controllers
{
    [Admin]
    public class UsuarioController : Controller
    {
        private AltaUsuario _alta;

        public UsuarioController(AltaUsuario alta)
        {
            _alta = alta;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DtoUsuarioAlta dto)
        {
            try
            {
                _alta.Ejecutar(dto);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(dto);
            }
        }
    }
    }