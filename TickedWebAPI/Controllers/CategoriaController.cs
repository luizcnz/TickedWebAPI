using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Services;
using TickedWebAPI.Repositories.Aplications;
using TickedWebAPI.Models;
using Microsoft.Data.SqlClient;
using TickedWebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly TickedContext _tickedContext;
        public CategoriaController(TickedContext tickedContext)
        {
            _tickedContext = tickedContext;
        }

        #region obtencion de categorias
        // GET: api/<CategoriaController>
        [HttpGet("/api/Categoria")]
        public Response GetCategorias()
        {
            GetDataService solicitud = new GetDataService(new ObtenerCategorias(_tickedContext));

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
        #endregion

        //GET: api/<CategoriaController>
        [HttpGet("/api/CategoriaSubcat")]
        public Response GetCategoriasSubcat()
        { 

            GetDataService solicitud = new GetDataService(new ObtenerCategoriasConArray(_tickedContext));
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
