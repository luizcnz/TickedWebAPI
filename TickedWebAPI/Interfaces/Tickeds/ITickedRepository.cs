using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Interfaces.Tickeds
{
    public interface ITickedRepository
    {
        Task<IEnumerable<TickedDto>> GetAllTickedsWithDetails();


        Task<IEnumerable<TickedDto>> GetAllTickedsByUserIdWithDetails(int UserId);


        Task<IEnumerable<TickedDto>> GetTickedByIdWithDetails(int TickedId);


        Task<IEnumerable<TickedDto>> CreateTicked(CrearTickedDto ticked);

    }
}
