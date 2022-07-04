using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Models;

namespace TickedWebAPI.Interfaces.Tickeds
{
    public interface ITickedDataVerify
    {
        string VerificarDatos([FromBody] CrearTickedDto ticked);
    }
}
