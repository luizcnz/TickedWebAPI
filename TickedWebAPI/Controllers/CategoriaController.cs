using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Services;
using TickedWebAPI.Repositories.Aplications;
using TickedWebAPI.Models;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        #region obtencion de categorias
        // GET: api/<CategoriaController>
        [HttpGet("/api/Categoria")] 
        public Response GetCategorias()
        {
            GetDataService solicitud = new GetDataService(new ObtenerCategorias(new SqlConnection()));
            var valor = (OkObjectResult)solicitud.ObtenerDatos().Result;
            return new Response{Message= "Datos obtenidos exitosamente", Data = valor.Value};
        }
        #endregion

        //GET: api/<CategoriaController>
        [HttpGet("/api/CategoriaSubcat")]
        public Response GetCategoriasSubcat()
        {
            GetDataService solicitud = new GetDataService(new ObtenerCategoriasConArray());
            var valor = (OkObjectResult)solicitud.ObtenerDatos().Result;
            return new Response{Message= "Datos obtenidos exitosamente", Data = valor.Value};
        }

    }
}
