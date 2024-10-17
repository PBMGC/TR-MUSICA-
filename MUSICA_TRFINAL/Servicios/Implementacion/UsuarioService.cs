using Microsoft.EntityFrameworkCore;
using MUSICA_TRFINAL.Models;
using MUSICA_TRFINAL.Servicios.Interfaces;

namespace MUSICA_TRFINAL.Servicios.Implementacion
{
    public class UsuarioService : IUsuario_service
    {
        private readonly MusicaTrContext _musicaTrContext;

        public UsuarioService(MusicaTrContext musicaTrContext)
        {
            _musicaTrContext = musicaTrContext;
        }

        public async Task<Usuario> GetUsuario(string usuario, string contraseña)
        {
            Usuario usuario_encontrado = await _musicaTrContext.Usuarios.Where(u=>u.NombreUsuario==usuario && u.Contraseña==contraseña)
                .FirstOrDefaultAsync();
            return usuario_encontrado;
        }
    }
}
