using Microsoft.AspNetCore.Mvc;
using MUSICA_TRFINAL.Models;
using MUSICA_TRFINAL.Servicios.Interfaces;

namespace MUSICA_TRFINAL.Controllers
{
    public class CancionesController : Controller
    {
        private readonly ICancion_service _cancion_service;

        // Inyección de dependencias del servicio de canciones
        public CancionesController(ICancion_service cancion_service)
        {
            _cancion_service = cancion_service;
        }

        // Acción para cargar la vista de Index con las canciones
        public async Task<IActionResult> Index()
        {
            // Obtener todas las canciones desde el servicio
            var todasLasCanciones = await _cancion_service.GetCanciones();

            // Pasar las canciones a la vista
            return View(todasLasCanciones);
        }
    }
}
