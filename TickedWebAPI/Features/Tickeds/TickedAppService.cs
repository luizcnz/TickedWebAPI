using TickedWebAPI.Interfaces.Tickeds;
using TickedWebAPI.Models;

namespace TickedWebAPI.Features.Tickeds
{
    public class TickedAppService : ITickedAppService
    {
        private readonly ITickedRepository tickedRepository;
        private readonly ITickedDataVerify tickedDataVerify;

        public TickedAppService(ITickedRepository tickedRepository, ITickedDataVerify tickedDataVerify)
        {
            this.tickedRepository = tickedRepository;
            this.tickedDataVerify = tickedDataVerify;
        }

        public async Task<Response> GetAllTickedsWithDetails()
        {
            var allTickeds = await tickedRepository.GetAllTickedsWithDetails();

            return new Response
            {
                Data = allTickeds
            };
        }

        public async Task<Response> GetAllTickedsByUserIdWithDetails(int UserId)
        {
            IEnumerable<TickedDto> allTickedByUser = await tickedRepository.GetAllTickedsByUserIdWithDetails(UserId);

            return new Response
            {
                Data = allTickedByUser
            };
        }

        public async Task<Response> GetTickedByIdWithDetails(int TickedId)
        {
            IEnumerable<TickedDto> TicketById = await tickedRepository.GetTickedByIdWithDetails(TickedId);

            return new Response
            {
                Data = TicketById
            };
        }

        public async Task<Response> CreateTicked(CrearTickedDto ticked)
        {
            string DataVerify = tickedDataVerify.VerificarDatos(ticked);
            if (DataVerify!=null)
            {
                return new Response
                {
                    Message = DataVerify
                };
            }

            IEnumerable<TickedDto> CreateTicked = await tickedRepository.CreateTicked(ticked);
            return new Response
            {
                Data = CreateTicked
            };
        }
    }
}
