using Microsoft.AspNetCore.Mvc;
using MUSICA_TRFINAL.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace MUSICA_TRFINAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ClaimsPrincipal claimUser = HttpContext.User;

            string nombre_usuario = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                nombre_usuario = claimUser.Claims.Where(c=>c.Type==ClaimTypes.Name)
                   .Select(c=>c.Value).SingleOrDefault();
            }

            ViewData["idusuario"] = nombre_usuario;

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
