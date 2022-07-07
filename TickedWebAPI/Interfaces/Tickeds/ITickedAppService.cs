using TickedWebAPI.Models;

namespace TickedWebAPI.Interfaces.Tickeds
{
    public interface ITickedAppService
    {
        Task<Response> GetAllTickedsWithDetails();
        Task<Response> GetAllTickedsWithDetailsByUserId(int UserId);
        Task<Response> GetTickedWithDetailsById(int TickedId);
        Task<Response> CreateTicked(CrearTickedDto ticked);
    }
}
