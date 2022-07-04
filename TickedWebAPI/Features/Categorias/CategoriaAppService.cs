using TickedWebAPI.Interfaces;
using TickedWebAPI.Interfaces.Categorias;
using TickedWebAPI.Models;

namespace TickedWebAPI.Features.Categorias
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaAppService(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public async Task<Response> GetAllCategorias()
        {
            IEnumerable<CategoriaDto> AllCategorias = await categoriaRepository.GetAllCategorias();
            return new Response
            {
                Data = AllCategorias
            };
        }

        public async Task<Response> GetAllCategoriasWithSubcategorias()
        {
            IEnumerable<CategoriaConSubcategoriasDto>AllCategoriasWithSubcategorias = await categoriaRepository.GetAllCategoriasWithSubcategorias();
            return new Response
            {
                Data = AllCategoriasWithSubcategorias
            };
        }

    }
}
