using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TickedWebAPI.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

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


        static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

        public static IConfigurationRoot configuration = builder.Build();

        public string conn = configuration.GetConnectionString("ConnectionString");


        #region obtener tickeds con llaves foraneas
        // GET: api/<TickedController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(App1Ticked))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetList()
        {
            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = conn;

            connString.Open();

            string procedureName = "[getTickeds]";
            var result = new List<App1Ticked>();

            try
            {
                using (SqlCommand command = new SqlCommand(procedureName,
            connString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.Add(new SqlParameter("@estado", 4));

                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string? numero = reader.GetStringOrNull(1);
                                string? descripcion = reader.GetStringOrNull(2);
                                string? adjunto = reader.GetStringOrNull(3);
                                DateTime? fechacreado = reader.GetDateOrNull(4);
                                string? estadoread = reader.GetStringOrNull(5);
                                string? prioridad = reader.GetStringOrNull(6);
                                string? subcategoria = reader.GetStringOrNull(7);
                                string? usuarioSolicitante = reader.GetStringOrNull(8);

                                App1Ticked tmpRecord = new App1Ticked()
                                {
                                    Numero = numero,
                                    Descripcion = descripcion,
                                    Adjunto = adjunto,
                                    Fechacreado = fechacreado,
                                    Estado = estadoread,
                                    Prioridad = prioridad,
                                    Subcategoria = subcategoria,
                                    UsuarioSolicitante = usuarioSolicitante

                                };
                                result.Add(tmpRecord);
                            }
                            connString.Close();
                            return new OkObjectResult(result);
                        }
                        else
                        {
                            connString.Close();
                            return new NotFoundObjectResult(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                connString.Close();
                return new StatusCodeResult(500);
            }
            
            
        }
        #endregion

         #region obtener tickeds por id de ticked con llaves foraneas
        // GET: api/<TickedController>
        [HttpGet("/tickedid/{TkId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(App1Ticked))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int TkId)
        {
            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = conn;

            connString.Open();

            string procedureName = "[getTickedsById]";
            
            var result = new List<App1Ticked>();
            try
            {
                using (SqlCommand command = new SqlCommand(procedureName,
                connString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", TkId));

                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string? numero = reader.GetStringOrNull(0);
                                string? descripcion = reader.GetStringOrNull(1);
                                string? adjunto = reader.GetStringOrNull(2);
                                DateTime? fechacreado = reader.GetDateOrNull(3);
                                string? estadoread = reader.GetStringOrNull(4);
                                string? prioridad = reader.GetStringOrNull(5);
                                string? subcategoria = reader.GetStringOrNull(6);
                                string? usuarioSolicitante = reader.GetStringOrNull(7);

                                App1Ticked tmpRecord = new App1Ticked()
                                {
                                    Numero = numero,
                                    Descripcion = descripcion,
                                    Adjunto = adjunto,
                                    Fechacreado = fechacreado,
                                    Estado = estadoread,
                                    Prioridad = prioridad,
                                    Subcategoria = subcategoria,
                                    UsuarioSolicitante = usuarioSolicitante

                                };
                                result.Add(tmpRecord);
                            }
                            connString.Close();
                            return new OkObjectResult(result);
                            //var response = new HttpResponseMessage();
                            //response.Content = new StringContent();
                            //return Request.CreateResponse<Employee>(HttpStatusCode.OK, emp);
                        }
                        else
                        {
                            connString.Close();
                            return new NotFoundObjectResult(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                connString.Close();
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region metodo post procedimiento almacenado en base de datos
        // POST api/<TickedController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(App1TickedPost))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] App1TickedPost ticked)
        {
            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = conn;

            connString.Open();

            string procedureName = "[postTicked]";

            string? Descripcion = ticked.Descripcion;
            string? Adjunto = ticked.Adjunto;
            DateTime? Fechacreado = ticked.Fechacreado;
            int? Estado = ticked.EstadoId;
            int? Prioridad = ticked.PrioridadId;
            int? Subcategoria = ticked.SubcategoriaId;
            int? UsuarioSolicitante = ticked.UsuarioSolicitanteId;


            try
            {
                SqlCommand command = new SqlCommand(procedureName,
                connString);
                
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(new SqlParameter("@Numero", Numero));
                command.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                command.Parameters.Add(new SqlParameter("@Adjunto", Adjunto));
                command.Parameters.Add(new SqlParameter("@Fechacreado", Fechacreado));
                command.Parameters.Add(new SqlParameter("@Estado", 1));
                command.Parameters.Add(new SqlParameter("@Prioridad", Prioridad));
                command.Parameters.Add(new SqlParameter("@Subcategoria", Subcategoria));
                //command.Parameters.Add(new SqlParameter("@Tratamiento", Tratamiento));
                command.Parameters.Add(new SqlParameter("@UsuarioSolicitante", UsuarioSolicitante));

                //using (SqlDataReader? reader = command.ExecuteReader())

                int id = (int)command.ExecuteScalar();

                string uri = "http://localhost:63877/tickedid/" + id+"";
                connString.Close();

                return Created(uri, ticked);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                connString.Close();
                //var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                //return response;
                return new StatusCodeResult(500);

            }

        }
        #endregion
    }

}

