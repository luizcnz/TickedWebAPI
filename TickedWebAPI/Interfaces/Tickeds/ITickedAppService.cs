using TickedWebAPI.Models;

namespace TickedWebAPI.Interfaces.Tickeds
{
    public interface ITickedAppService
    {
        Task<Response> GetAllTickedsWithDetails();

        Task<Response> GetAllTickedsByUserIdWithDetails(int UserId);

        Task<Response> GetTickedByIdWithDetails(int TickedId);

        Task<Response> CreateTicked(CrearTickedDto ticked);

    }
}
