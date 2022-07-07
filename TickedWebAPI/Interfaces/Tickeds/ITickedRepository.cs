using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Interfaces.Tickeds
{
    public interface ITickedRepository
    {
        Task<IEnumerable<TickedDto>> GetAllTickedsWithDetails();
        Task<IEnumerable<TickedDto>> GetAllTickedsWithDetailsByUserId(int UserId);
        Task<IEnumerable<TickedDto>> GetTickedWithDetailsById(int TickedId);
        Task<IEnumerable<TickedDto>> CreateTicked(CrearTickedDto ticked);
    }
}
