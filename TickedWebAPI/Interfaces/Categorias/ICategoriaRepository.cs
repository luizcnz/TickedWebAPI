using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Interfaces.Categorias
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<CategoriaDto>> GetAllCategorias();
        Task<IEnumerable<CategoriaConSubcategoriasDto>> GetAllCategoriasWithSubcategorias();
    }
}
