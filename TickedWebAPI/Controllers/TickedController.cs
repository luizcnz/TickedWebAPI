using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Models;
using TickedWebAPI.Services;
using TickedWebAPI.Repositories.Aplications;
using TickedWebAPI.Repositories;

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickedController : ControllerBase
    {
        #region obtener tickeds con llaves foraneas
        // GET: api/<TickedController>
        [HttpGet]
        public Response GetAllTickeds()
        {
            GetDataService solicitud = new GetDataService(new ObtenerTickeds());
            //return await solicitud.ObtenerDatos();

            var valor = (OkObjectResult)solicitud.ObtenerDatos().Result;
            
            return new Response{Message= "Datos obtenidos exitosamente", Data = valor.Value};
        }
        #endregion


        #region obtener tickeds por id de ticked con llaves foraneas
        // GET: api/<TickedController>
        [HttpGet("/api/Ticked/tickedid/{TkId}")]
        public Response GetTicked(int TkId)
        {
            GetDataByIdService solicitud = new GetDataByIdService(new ObtenerTickedPorId());
            //return await solicitud.ObtenerDatosPorId(TkId);
            var valor = (OkObjectResult)solicitud.ObtenerDatosPorId(TkId).Result;
            
            return new Response{Message= "Datos obtenidos exitosamente", Data = valor.Value};
        }
        #endregion


        #region obtener tickeds por solicitante del ticked con llaves foraneas
        // GET: api/<TickedController>
        [HttpGet("/api/Ticked/userid/{UserId}")]
        public Response GetUserTickeds(int UserId)
        {
            GetDataByIdService solicitud = new GetDataByIdService(new ObtenerTickedsPorIdDeUsuario());
            var valor = (OkObjectResult)solicitud.ObtenerDatosPorId(UserId).Result;
            //var valor = (OkObjectResult)respuesta.Result;
            return new Response{Message= "Datos obtenidos exitosamente", Data = valor.Value};
        }
        #endregion

        // POST api/<TickedController>
        [HttpPost]
        public Response Post([FromBody] App1TickedPost ticked)
        {

            bool existePrioridad = DataCheck.VerificarExistencia("[checkPrioridad]", ticked.PrioridadId);
            bool existeSubcategoria = DataCheck.VerificarExistencia("[checkSubcategoria]", ticked.SubcategoriaId);
            bool existeUsuario = DataCheck.VerificarExistencia("[checkUser]", ticked.UsuarioSolicitanteId);

            if (ticked.Descripcion == null)
            {
                return new Response{Message ="Debe ingresar una descripcion"};
            }
            if (ticked.Fechacreado == null)
            {
                return new Response{Message ="Debe ingresar una fecha"};
            }
            if (existePrioridad == false)
            {
                return new Response{Message ="Debe ingresar una prioridad valida"};
            }
            if (existeSubcategoria == false)
            {
                return new Response{Message ="Debe ingresar una subcategoria valida"};
            }
            if (existeUsuario == false)
            {
                return new Response{Message ="Debe ingresar un usuario valido"};
            }
                

            PostDataService solicitud = new PostDataService(new CrearTicked());

            var valor = (OkObjectResult)solicitud.InsertarDatos(ticked).Result;
             
            if(valor.Value == null)
            {
              return new Response{Message= "Hubo un error al guardar el ticked"};  
            }

            return new Response{Message= "Ticked creado exitosamente", Data = valor.Value};

        }

    }
}

