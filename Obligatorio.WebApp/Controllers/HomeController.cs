using Microsoft.AspNetCore.Mvc;
using Obligatorio.WebApp.Filtros;
using Obligatorio.WebApp.Models;
using System.Diagnostics;

namespace Obligatorio.WebApp.Controllers
{
    [Admin]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
