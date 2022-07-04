using TickedWebAPI.Models;

namespace TickedWebAPI.Interfaces
{
    public interface IPrioridadAppService
    {
        Task<Response> GetAllPrioridades();
    }
}
