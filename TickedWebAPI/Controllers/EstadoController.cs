using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Services;
using TickedWebAPI.Models;
using TickedWebAPI.Repositories.Aplications;
using TickedWebAPI.Repositories;
using TickedWebAPI.Interfaces;
using Microsoft.Data.SqlClient;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {

        private readonly TickedContext _tickedContext;
        public EstadoController(TickedContext tickedContext)
        {
            _tickedContext = tickedContext;
        }

        #region obtener estados
        // GET: api/<EstadoControllerController>
        [HttpGet]
        public Response GetEstados()
        {
            GetDataService solicitud = new GetDataService(new ObtenerEstados(_tickedContext));
            var valor = (OkObjectResult)solicitud.ObtenerDatos().Result;
            
            if (Convert.ToString(valor.Value) == "NoResult")
            {
                return new Response { Message = "No se encontraron datos" };
            }
            if (valor.Value == null)
            {
                return new Response { Message = "Hubo un error al obtener los datos" };
            }
            return new Response { Message = "Datos obtenidos exitosamente", Data = valor.Value };
        }
        #endregion
    }
}
