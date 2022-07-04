using TickedWebAPI.Models;

namespace TickedWebAPI.Interfaces
{
    public interface ISubcategoriaAppService
    {
        Task<Response> GetAllSubcategorias();
        Task<Response> GetAllSubcategoriasByCategoriaId(int CatId);
    }
}
