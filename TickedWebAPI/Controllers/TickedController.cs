using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TickedWebAPI.Models;


using System.Data;
using System.Threading.Tasks;
using System.Text;

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
        public IEnumerable<TickedGET> Get()
        {
            var items = context.App1Tickeds.Take(5)
            .Select(p => new TickedGET()
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
                UsuarioSolicitante = p.UsuarioSolicitante.FirstName
            })
            .ToList();

            return items;
        }


        // GET api/<TickedController>/5
        [HttpGet("{id}")]
        public IEnumerable<App1Ticked> Get(int id)
        {
            //var ticket = context.App1Tickeds.Where(p => p.EstadoId == id).Take(10);
            var ticket = context.App1Tickeds.Take(3);
            return ticket;
        }

        // POST api/<TickedController>
        [HttpPost]
        public ActionResult Post([FromBody]App1TickedPost ticked)
        {

            string connString = @"Server =localhost; Database = ticked; Trusted_Connection = True;";

            int Estado, Prioridad, Subcategoria, Tecnico, TipoAsistencia, Tratamiento, UsuarioSolicitante;
            DateTime Fechacreado, FechaAtendido, FechaCerrado;
            string Adjunto, Descripcion, Numero;

            Numero = ticked.Numero;
            Descripcion = ticked.Descripcion;
            Adjunto = ticked.Adjunto;
            Fechacreado = (DateTime)ticked.Fechacreado;
            Estado = (int)ticked.EstadoId;
            Prioridad = (int)ticked.PrioridadId;
            Subcategoria = (int)ticked.SubcategoriaId;
            Tecnico = (int)ticked.TecnicoId;
            TipoAsistencia = (int)ticked.TipoAsistenciaId;
            Tratamiento = (int)ticked.TratamientoId;
            UsuarioSolicitante = (int)ticked.UsuarioSolicitanteId;



            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {

                    string query = @"INSERT into app1_ticked (
                                    numero
                                    ,descripcion
                                    ,adjunto
                                    ,fechacreado
                                    ,estado_id
                                    ,prioridad_id
                                    ,subcategoria_id
                                    ,tecnico_id
                                    ,tipoAsistencia_id
                                    ,tratamiento_id
                                    ,usuarioSolicitante_id) VALUES ('" + Numero+ "','" + Descripcion+ "','" +Adjunto+ "','" + Fechacreado+ "'," + Estado+ ","+Prioridad+ ","+Subcategoria+ ","+Tecnico+ ","+TipoAsistencia+ ","+Tratamiento+ ","+UsuarioSolicitante+ ");" ;

                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Iniciando insercion de datos..." + Environment.NewLine);
                    

                    //close data reader
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }

            return Ok();

        }

    }

    public class TickedGET
    {
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
    }

    public class App1TickedPost
    {
        public string? Numero { get; set; }
        public string? Descripcion { get; set; }
        public string? Adjunto { get; set; }
        public DateTime? Fechacreado { get; set; }

        public int? EstadoId { get; set; }

        public int? PrioridadId { get; set; }

        public int? SubcategoriaId { get; set; }
        public int? TecnicoId { get; set; }
        public int? TipoAsistenciaId { get; set; }
        public int? TratamientoId { get; set; }
        public int? UsuarioSolicitanteId { get; set; }
    }
}

