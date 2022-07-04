using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Interfaces.Estados
{
    public interface IEstadoRepository
    {
        Task<IEnumerable<EstadoDto>> GetAllEstados();
    }
}
