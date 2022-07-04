using TickedWebAPI.Models;

namespace TickedWebAPI.Interfaces.Estados
{
    public interface IEstadoAppService
    {
        Task<Response> GetAllEstados();
    }
}
