using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TickedWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickedController : ControllerBase
    {
        private readonly tickedContext context;
        

        public TickedController(tickedContext context)
        {
            this.context = context;
        }

        // GET: api/<TickedController>
        [HttpGet]
        public IEnumerable<TickedDto> Get()
        {

            var items = context.App1Tickeds.Take(20)
                //Include(x => ((App1Estado)x).Estado).
                //.Include(x => x.Subcategoria).


                //.Include(x => x.Estado).ThenInclude(x => x.Estado)

                .Select(p => new TickedDto()
                {
                    Id = p.Id,
                    Numero = p.Numero,
                    Descripcion = p.Descripcion,
                    Adjunto = p.Adjunto,
                    Fechacreado = p.Fechacreado,
                    FechaAtendido = p.FechaAtendido,
                    FechaCerrado = p.FechaCerrado,
                    Estado = p.Estado.Estado,
                    Prioridad = p.Prioridad.Prioridad,
                    Subcategoria = p.Subcategoria.Subcategoria,
                    Tecnico = p.Tecnico.FirstName,
                    TipoAsistencia = p.TipoAsistencia.Asistencia,
                    Tratamiento = p.Tratamiento.Tratamiento,
                    UsuarioSolicitante = p.UsuarioSolicitante.FirstName,

                    //App1Detalletickeds = p.App1Detalletickeds,
                    //App1Registrotransferencia = p.App1Registrotransferencia
                })
                .ToList();

            return items;
            //return null;

            //return context.App1Tickeds.ToList().Take(10);
            
        }

        // GET api/<TickedController>/5
        [HttpGet("{id}")]
        public IEnumerable<App1Ticked> Get(int id)
        {
            //var ticket = context.App1Tickeds.Where(p => p.EstadoId == id).Take(10);
            var ticket = context.App1Tickeds.Take(10);
            return ticket;
        }

        // POST api/<TickedController>
        [HttpPost]
        public ActionResult Post([FromBody]App1Ticked ticked)
        {
            try
            {
                context.App1Tickeds.Add(ticked);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        
    }

    public class TickedDto
    {

        //public TickedDto()
        //{
        //    App1Detalletickeds = new HashSet<App1Detalleticked>();
        //    App1Registrotransferencia = new HashSet<App1Registrotransferencium>();
        //}
        public int? Id { get; set; }
        public string? Numero { get; set; }
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public DateTime? Fechacreado { get; set; }
        public DateTime? FechaAtendido { get; set; }
        public DateTime? FechaCerrado { get; set; }
        public string? Estado { get; set; }
        public string? Prioridad { get; set; }
        public string? Subcategoria { get; set; }
        public string? Tecnico { get; set; }
        public string? TipoAsistencia { get; set; }
        public string? Tratamiento { get; set; }
        public string? UsuarioSolicitante { get; set; }

        //public virtual ICollection<App1Detalleticked> App1Detalletickeds { get; set; }
        //public virtual ICollection<App1Registrotransferencium> App1Registrotransferencia { get; set; }

        
    }
}

