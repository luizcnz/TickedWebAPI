using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Models;
using TickedWebAPI.Services;
using TickedWebAPI.Repositories.Aplications;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadController : ControllerBase
    {
        // GET: api/<PrioridadController>
        [HttpGet]
        public Response GetPrioridades()
        {
            GetDataService solicitud = new GetDataService(new ObtenerPrioridades());
            var valor = (OkObjectResult)solicitud.ObtenerDatos().Result;
            
            return new Response{Message= "Datos obtenidos exitosamente", Data = valor.Value};
        }
    }
}
