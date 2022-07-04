using TickedWebAPI.Interfaces.Estados;
using TickedWebAPI.Models;

namespace TickedWebAPI.Features.Estados
{
    public class EstadoAppService : IEstadoAppService
    {
        private readonly IEstadoRepository estadoRepository;

        public EstadoAppService(IEstadoRepository estadoRepository)
        {
            this.estadoRepository = estadoRepository;
        }

        public async Task<Response> GetAllEstados()
        {
            IEnumerable<EstadoDto> allEstados = await estadoRepository.GetAllEstados();

            return new Response
            {
                Data = allEstados
            };
        }

    }
}
