using MUSICA_TRFINAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MUSICA_TRFINAL.Servicios.Interfaces
{
    public interface ICancion_service
    {
        Task<List<Canciones>> GetCanciones(); 
        Task<List<string>> GetGeneros();    
        Task<List<string>> GetCantantes();  
    }
}
