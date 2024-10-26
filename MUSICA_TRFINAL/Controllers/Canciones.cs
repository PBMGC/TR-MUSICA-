using Microsoft.AspNetCore.Mvc;
using MUSICA_TRFINAL.Models;
using MUSICA_TRFINAL.Servicios.Implementacion;
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

        public async Task<IActionResult> Generos ()
        {
            var generos = await _cancion_service.GetGeneros();
            return View("/Views/Generos/generos.cshtml", generos);
        }

        public async Task<IActionResult> Cantantes()
        {
            var cantantes = await _cancion_service.GetCantantes();
            return View("/Views/Cantantes/cantantes.cshtml", cantantes);
        }

        public IActionResult GuardarCancion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCancion(Canciones modelo)
        {
            Canciones cancion_creada = await _cancion_service.SaveCancion(modelo);
            if (cancion_creada.CancionID > 0)
            {
                var imagenPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");

                var nombreFile = $"{cancion_creada.CancionID}.jpg";
                var completo = Path.Combine(imagenPath,nombreFile);

                using (var stream = new FileStream(completo, FileMode.Create))
                {
                    await modelo.Imagen.CopyToAsync(stream);
                } 

                    return RedirectToAction("Index", "Home");
            }

            ViewData["Mensaje"] = "No se pudo crear";
            return View();
        }


    }
}
