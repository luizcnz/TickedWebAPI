using TickedWebAPI.Interfaces;
using TickedWebAPI.Interfaces.Prioridades;
using TickedWebAPI.Models;

namespace TickedWebAPI.Features.Prioridades
{
    public class PrioridadAppService : IPrioridadAppService
    {
        private readonly IPrioridadRepository prioridadRepository;

        public PrioridadAppService(IPrioridadRepository prioridadRepository)
        {
            this.prioridadRepository = prioridadRepository;
        }

        public async Task<Response> GetAllPrioridades()
        {
            IEnumerable<PrioridadDto> AllPrioridades = await this.prioridadRepository.GetAllPrioridades();

            return new Response 
            {
                Data = AllPrioridades
            };
        }
    }
}
