using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Services;
using TickedWebAPI.Repositories.Aplications;
using TickedWebAPI.Models;
using TickedWebAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private readonly TickedContext _tickedContext;
        public SubcategoriaController(TickedContext tickedContext)
        {
            _tickedContext = tickedContext;
        }

        #region get de categorias sin filtro con llaves foraneas
        // GET: api/<SubcategoriaController>
        [HttpGet]
        public Response GetSubcategorias()
        {
            GetDataService solicitud = new GetDataService(new ObtenerSubcategorias(_tickedContext));
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

        #region get de subcategorias segun id de categoria con llave foranea
        [HttpGet("{CatId}")]
        public Response GetSubcategoriasById(int CatId)
        {
            GetDataByIdService solicitud = new GetDataByIdService(new ObtenerSubcategoriasPorId(_tickedContext));
            var valor = (OkObjectResult)solicitud.ObtenerDatosPorId(CatId).Result;
            if (Convert.ToString(valor.Value) == "NoResult")
            {
                return new Response { Message = "No se encontraron datos con el id: " + CatId };
            }
            if (Convert.ToString(valor.Value) == "Error")
            {
                return new Response { Message = "Hubo un error al obtener los datos" };
            }
            return new Response { Message = "Datos obtenidos exitosamente", Data = valor.Value };
        }
        #endregion

    }
}
