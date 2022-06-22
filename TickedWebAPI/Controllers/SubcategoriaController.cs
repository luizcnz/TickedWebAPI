using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Services;
using TickedWebAPI.Repositories.Aplications;
using TickedWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {

        #region get de categorias sin filtro con llaves foraneas
        // GET: api/<SubcategoriaController>
        [HttpGet]
        public Response GetSubcategorias()
        {
            GetDataService solicitud = new GetDataService(new ObtenerSubcategorias());
            var valor = (OkObjectResult)solicitud.ObtenerDatos().Result;
            
            return new Response{Message= "Datos obtenidos exitosamente", Data = valor.Value};
        }
        #endregion

        #region get de subcategorias segun id de categoria con llave foranea
        [HttpGet("{CatId}")]
        public Response GetSubcategoriasById(int CatId)
        {
            GetDataByIdService solicitud = new GetDataByIdService(new ObtenerSubcategoriasPorId());
            //return await solicitud.ObtenerDatosPorId(CatId);

            var valor = (OkObjectResult)solicitud.ObtenerDatosPorId(CatId).Result;
            
            return new Response{Message= "Datos obtenidos exitosamente", Data = valor.Value};
        }
        #endregion

    }
}
