using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Interfaces.Tickeds
{
    public interface ITickedRepository
    {
        Task<IEnumerable<TickedDto>> GetAllTickedsWithDetail();


        Task<IEnumerable<TickedDto>> GetAllTickedsWithDetailByUserId(int UserId);


        Task<IEnumerable<TickedDto>> GetTickedWithDetailById(int TickedId);


        Task<IEnumerable<TickedDto>> CreateTicked(CrearTickedDto ticked);

    }
}
