using Microsoft.EntityFrameworkCore;
using MUSICA_TRFINAL.Models;

namespace MUSICA_TRFINAL.Servicios.Interfaces
{
    public interface IUsuario_service
    {
        Task<Usuario> GetUsuario(string usuario, string contraseña);
        Task<Usuario> SaveUsuario(Usuario usuario);
    }
}
