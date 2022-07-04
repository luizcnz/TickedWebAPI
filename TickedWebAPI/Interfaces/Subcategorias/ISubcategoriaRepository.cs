using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Interfaces.Subcategorias
{
    public interface ISubcategoriaRepository
    {
        Task<IEnumerable<SubcategoriaConInnerJoinDto>> GetAllSubcategorias();
        Task<IEnumerable<SubcategoriaConInnerJoinDto>> GetAllSubcategoriasByCategoriaId(int CatID);
    }
}
