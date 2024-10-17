using Microsoft.AspNetCore.Mvc;

using MUSICA_TRFINAL.Models;
using MUSICA_TRFINAL.Recursos;
using MUSICA_TRFINAL.Servicios.Interfaces;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MUSICA_TRFINAL.Controllers
{
    public class Inicio : Controller
    {
        private readonly IUsuario_service _usuario_service;

        public Inicio(IUsuario_service usuario_Service)
        {
            _usuario_service = usuario_Service;
        }
        public IActionResult Logearse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logearse(string usuario, string contraseña)
        {
            Usuario usuario_encontrado = await _usuario_service.GetUsuario(usuario, contraseña);

            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontro";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usuario_encontrado.Id.ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    properties
                );

            return RedirectToAction("Index","Home");
        }


    }
}
