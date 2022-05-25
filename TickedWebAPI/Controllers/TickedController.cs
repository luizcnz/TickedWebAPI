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
        public async Task<IActionResult> GetAllTickeds()
        {
            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = conn;
            connString.Open();

            SqlConnection connString2 = new SqlConnection();
            connString2.ConnectionString = conn;
            connString2.Open();

            string procedureName = "[getTickeds]";
            string procedureName2 = "[getDetalles]";
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
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string? numero;
                                if (reader.IsDBNull(1))
                                {
                                    numero = "Numero Pendiente";
                                }
                                else
                                {
                                    numero = reader.GetString(1);
                                }
                                string? descripcion = reader.GetStringOrNull(2);
                                string? adjunto = reader.GetStringOrNull(3);
                                string? fechacreado;
                                if (reader.IsDBNull(4))
                                {
                                    fechacreado = "Fecha Pendiente";
                                }
                                else
                                {
                                    fechacreado = Convert.ToString(reader.GetDateTime(4));
                                }
                                string? fechaatendido;
                                if (reader.IsDBNull(5))
                                {
                                    fechaatendido = "Pendiente";
                                }
                                else
                                {
                                    fechaatendido = Convert.ToString(reader.GetDateTime(5));
                                }
                                string? estadoread = reader.GetStringOrNull(6);
                                string? prioridad = reader.GetStringOrNull(7);
                                string? subcategoria = reader.GetStringOrNull(8);
                                string? usuarioSolicitante = reader.GetStringOrNull(9);
                                var detalles = new List<App1DetalleTicked>();
                                // Inicio del codigo para obtener los detalles del ticked
                                try
                                {
                                    using (SqlCommand command2 = new SqlCommand(procedureName2,
                                    connString2))
                                    {
                                        command2.CommandType = CommandType.StoredProcedure;
                                        command2.Parameters.Add(new SqlParameter("@NumId", id));
                                        using (SqlDataReader? reader2 = command2.ExecuteReader())
                                        {
                                            if (reader2.HasRows)
                                            {
                                                while (reader2.Read())
                                                {
                                                    DateTime detalleFecha = reader2.GetDateTime(0);
                                                    string detalleComentario = reader2.GetString(1);
                                                    string detalleUsuario = reader2.GetString(2);
                                                    string detalleAdjunto = reader2.GetString(3);

                                                    App1DetalleTicked tmp = new App1DetalleTicked()
                                                    {
                                                        Fecha = detalleFecha,
                                                        Comentario = detalleComentario,
                                                        Usuario = detalleUsuario,
                                                        Adjunto = detalleAdjunto
                                                    };
                                                    detalles.Add(tmp);
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    connString.Close();
                                    connString2.Close();
                                    Console.Write("Se han encontrado los siguientes errores mientras se obtenian lo detalles: " + ex + "");
                                    return new StatusCodeResult(500);
                                }

                                App1Ticked tmpRecord = new App1Ticked()
                                {
                                    Numero = numero,
                                    Descripcion = descripcion,
                                    Adjunto = adjunto,
                                    Fechacreado = fechacreado,
                                    Fechaatendido = fechaatendido,
                                    Estado = estadoread,
                                    Prioridad = prioridad,
                                    Subcategoria = subcategoria,
                                    UsuarioSolicitante = usuarioSolicitante,
                                    Detalles = detalles

                                };
                                result.Add(tmpRecord);
                            }
                            connString.Close();
                            connString2.Close();
                            return new OkObjectResult(result);
                        }
                        else
                        {
                            connString.Close();
                            connString2.Close();
                            return new StatusCodeResult(404);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                connString.Close();
                Console.Write("Se han encontrado los siguientes errores mientras se obtenian lo detalles: " + ex + "");
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
        public async Task<IActionResult> GetTicked(int TkId)
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
                                string? numero;
                                if (reader.IsDBNull(0))
                                {
                                    numero = "Numero Pendiente";
                                }
                                else
                                {
                                    numero = reader.GetString(0);
                                }
                                string? descripcion = reader.GetStringOrNull(1);
                                string? adjunto = reader.GetStringOrNull(2);
                                string? fechacreado;
                                if (reader.IsDBNull(3))
                                {
                                    fechacreado = "Fecha Pendiente";
                                }
                                else
                                {
                                    fechacreado = Convert.ToString(reader.GetDateTime(3));
                                }
                                string? fechaatendido;
                                if (reader.IsDBNull(4))
                                {
                                    fechaatendido = "Fecha Pendiente";
                                }
                                else
                                {
                                    fechaatendido = Convert.ToString(reader.GetDateTime(4));
                                }
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
                                    Fechaatendido = fechaatendido,
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
                            return new StatusCodeResult(404);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                connString.Close();
                Console.Write("Se ha capturado el siguiente error: " + ex + "");
                return new StatusCodeResult(500);
            }
        }
        #endregion


        #region obtener tickeds por solicitante del ticked con llaves foraneas
        // GET: api/<TickedController>
        [HttpGet("/user/{UserId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(App1Ticked))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserTickeds(int UserId)
        {
            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = conn;
            connString.Open();

            SqlConnection connString2 = new SqlConnection();
            connString2.ConnectionString = conn;
            connString2.Open();

            string procedureName = "[getTickedsByUserId]";
            string procedureName2 = "[getDetalles]";

            var result = new List<App1Ticked>();
            try
            {
                using (SqlCommand command = new SqlCommand(procedureName,
                connString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserId", UserId));

                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string? numero;
                                if (reader.IsDBNull(1))
                                {
                                    numero = "Numero Pendiente";
                                }
                                else
                                {
                                    numero = reader.GetString(1);
                                }
                                string? descripcion = reader.GetStringOrNull(2);
                                string? adjunto = reader.GetStringOrNull(3);
                                string? fechacreado;
                                if (reader.IsDBNull(4))
                                {
                                    fechacreado = "Fecha Pendiente";
                                }
                                else
                                {
                                    fechacreado = Convert.ToString(reader.GetDateTime(4));
                                }
                                string? fechaatendido;
                                if (reader.IsDBNull(5))
                                {
                                    fechaatendido = "Pendiente";
                                }
                                else
                                {
                                    fechaatendido = Convert.ToString(reader.GetDateTime(5));
                                }
                                string? estadoread = reader.GetStringOrNull(6);
                                string? prioridad = reader.GetStringOrNull(7);
                                string? subcategoria = reader.GetStringOrNull(8);
                                string? usuarioSolicitante = reader.GetStringOrNull(9);
                                var detalles = new List<App1DetalleTicked>();

                                // Inicio del codigo para obtener los detalles del ticked
                                try
                                {
                                    using (SqlCommand command2 = new SqlCommand(procedureName2,
                                    connString2))
                                    {
                                        command2.CommandType = CommandType.StoredProcedure;
                                        command2.Parameters.Add(new SqlParameter("@NumId", id));
                                        using (SqlDataReader? reader2 = command2.ExecuteReader())
                                        {
                                            if (reader2.HasRows)
                                            {
                                                while (reader2.Read())
                                                {
                                                    DateTime detalleFecha = reader2.GetDateTime(0);
                                                    string detalleComentario = reader2.GetString(1);
                                                    string detalleUsuario = reader2.GetString(2);
                                                    string detalleAdjunto = reader2.GetString(3);

                                                    App1DetalleTicked tmp = new App1DetalleTicked()
                                                    {
                                                        Fecha = detalleFecha,
                                                        Comentario = detalleComentario,
                                                        Usuario = detalleUsuario,
                                                        Adjunto = detalleAdjunto
                                                    };
                                                    detalles.Add(tmp);
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    connString.Close();
                                    connString2.Close();
                                    Console.Write("Se han encontrado los siguientes errores mientras se obtenian lo detalles: " + ex + "");
                                    return new StatusCodeResult(500);
                                }


                                App1Ticked tmpRecord = new App1Ticked()
                                {
                                    Numero = numero,
                                    Descripcion = descripcion,
                                    Adjunto = adjunto,
                                    Fechacreado = fechacreado,
                                    Fechaatendido = fechaatendido,
                                    Estado = estadoread,
                                    Prioridad = prioridad,
                                    Subcategoria = subcategoria,
                                    UsuarioSolicitante = usuarioSolicitante,
                                    Detalles = detalles
                                };
                                result.Add(tmpRecord);
                            }
                            connString.Close();
                            return new OkObjectResult(result);
                        }
                        else
                        {
                            connString.Close();
                            return new StatusCodeResult(404);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                connString.Close();
                Console.Write("Se ha capturado el siguiente error: " + ex + "");
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

                string uri = "http://localhost:63877/tickedid/" + id + "";
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

