using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.CasosDeUso.Historias;
using Obligatorio.LogicaAplicacion.DTO;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;
using Obligatorio.WebApp.Filtros;

namespace Obligatorio.WebApp.Controllers
{
    [Admin]
    public class HistoriaController : Controller
    {
        private CrearHistoria _crear;
        private IRepositorioCategoria _repoCategoria;

        public HistoriaController(CrearHistoria crear, IRepositorioCategoria repoCategoria)
        {
            _crear = crear;
            _repoCategoria = repoCategoria;
        }

        public IActionResult Create()
        {
            ViewBag.Categorias = _repoCategoria.Listar();
            return View();
        }

        [HttpPost]
        public IActionResult Create(DtoHistoriaAlta historia)
        {
            try
            {
                _crear.Ejecutar(historia);
                return RedirectToAction("Index", "Home");
            }
            catch (LogicaNegocioException e)
            {
                ViewBag.Error = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Message = "Hubo un error interno.";
            }

            ViewBag.Categorias = _repoCategoria.Listar();
            return View(historia);
        }
    }
}