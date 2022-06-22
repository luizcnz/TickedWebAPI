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

        #region obtener estados
        // GET: api/<EstadoControllerController>
        [HttpGet]
        public Response GetEstados()
        {
            GetDataService solicitud = new GetDataService(new ObtenerEstados(new SqlConnection()));
            var valor = (OkObjectResult)solicitud.ObtenerDatos().Result;
            return new Response{Message= "Datos obtenidos exitosamente", Data = valor.Value};
        }
        #endregion
    }
}
