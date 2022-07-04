using TickedWebAPI.Models;

namespace TickedWebAPI.Interfaces.Categorias
{
    public interface ICategoriaAppService
    {
        Task<Response> GetAllCategorias();

        Task<Response> GetAllCategoriasWithSubcategorias();
    }
}
