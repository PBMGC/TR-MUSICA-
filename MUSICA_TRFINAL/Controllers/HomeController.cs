using Microsoft.AspNetCore.Mvc;
using MUSICA_TRFINAL.Models;
using MUSICA_TRFINAL.Servicios.Interfaces;
using System.Diagnostics;
using System.Security.Claims;

namespace MUSICA_TRFINAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICancion_service _cancion_service;

        // Inyección de dependencias del servicio de canciones
        public HomeController(ILogger<HomeController> logger, ICancion_service cancion_service)
        {
            _logger = logger;
            _cancion_service = cancion_service;
        }

        // Acción para cargar la vista de Index con las canciones
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string nombre_usuario = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                nombre_usuario = claimUser.Claims
                    .Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["idusuario"] = nombre_usuario;

            // Obtener todas las canciones desde el servicio
            var todasLasCanciones = await _cancion_service.GetCanciones();

            // Pasar las canciones a la vista
            return View(todasLasCanciones);
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
