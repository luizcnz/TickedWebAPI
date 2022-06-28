using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Models;
using TickedWebAPI.Services;
using TickedWebAPI.Repositories.Aplications;
using TickedWebAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadController : ControllerBase
    {

        private readonly TickedContext _tickedContext;
        public PrioridadController(TickedContext tickedContext)
        {
            _tickedContext = tickedContext;
        }
        // GET: api/<PrioridadController>
        [HttpGet]
        public Response GetPrioridades()
        {
            GetDataService solicitud = new GetDataService(new ObtenerPrioridades(_tickedContext));
            var valor = (OkObjectResult)solicitud.ObtenerDatos().Result;
            
            if (Convert.ToString(valor.Value) == "NoResult")
            {
                return new Response { Message = "No se encontraron datos" };
            }
            if (Convert.ToString(valor.Value) == "Error")
            {
                return new Response { Message = "Hubo un error al obtener los datos" };
            }
            return new Response { Message = "Datos obtenidos exitosamente", Data = valor.Value };
        }
    }
}
