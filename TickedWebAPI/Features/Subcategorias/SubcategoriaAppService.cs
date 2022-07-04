using TickedWebAPI.Interfaces;
using TickedWebAPI.Interfaces.Subcategorias;
using TickedWebAPI.Models;

namespace TickedWebAPI.Features.Subcategorias
{
    public class SubcategoriaAppService : ISubcategoriaAppService
    {
        private readonly ISubcategoriaRepository subcategoriaRepository;

        public SubcategoriaAppService(ISubcategoriaRepository subcategoriaRepository)
        {
            this.subcategoriaRepository = subcategoriaRepository;
        }

        public async Task<Response> GetAllSubcategorias()
        {
            IEnumerable<SubcategoriaConInnerJoinDto> AllSubcategorias = await this.subcategoriaRepository.GetAllSubcategorias();
            return new Response
            {
                Data = AllSubcategorias
            };
        }

        public async Task<Response> GetAllSubcategoriasByCategoriaId(int CatId)
        {
            IEnumerable<SubcategoriaConInnerJoinDto> AllSubcategoriasByCategoriaId = await this.subcategoriaRepository.GetAllSubcategoriasByCategoriaId(CatId);
            return new Response
            {
                Data = AllSubcategoriasByCategoriaId
            };
        }
    }
}
