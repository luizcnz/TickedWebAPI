using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Models;

namespace TickedWebAPI.Interfaces.Tickeds
{
    public interface ITickedPostVerify
    {
        string VerificarDatos([FromBody] CrearTickedDto ticked);
    }
}
