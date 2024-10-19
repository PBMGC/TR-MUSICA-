using Microsoft.EntityFrameworkCore;
using MUSICA_TRFINAL.Models;
using MUSICA_TRFINAL.Servicios.Interfaces;

namespace MUSICA_TRFINAL.Servicios.Implementacion
{
    public class CancionesService : ICancion_service
    {
        private readonly MusicaTrContext _musicaTrContext;

        public CancionesService(MusicaTrContext musicaTrContext)
        {
            _musicaTrContext = musicaTrContext;
        }

        public async Task<List<Canciones>> GetCanciones()
        {
            return await _musicaTrContext.Canciones.ToListAsync(); 
        }

        public async Task<List<string>> GetGeneros()
        {
            List<string> generosUnicos = await _musicaTrContext.Canciones
                .Select(c => c.Genero)
                .Distinct()
                .ToListAsync();
            return generosUnicos;
        }

        public async Task<List<string>> GetCantantes()
        {
            List<string> cantantesUnicos = await _musicaTrContext.Canciones
                .Select(c => c.Cantante)
                .Distinct()
                .ToListAsync();
            return cantantesUnicos;
        }

    }
}
