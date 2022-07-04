using TickedWebAPI.Models;

namespace TickedWebAPI.Interfaces.Prioridades
{
    public interface IPrioridadRepository
    {
        Task<IEnumerable<PrioridadDto>> GetAllPrioridades();
    }
}
