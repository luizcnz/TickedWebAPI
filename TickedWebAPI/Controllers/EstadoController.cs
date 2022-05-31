using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TickedWebAPI.Models;
using TickedWebAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly tickedContext context;
        public EstadoController(tickedContext context)
        {
            this.context = context;
        }

        #region obtener Prioridades
        // GET: api/<EstadoControllerController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Estado))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = ConnectionConf.conn;
            connString.Open();

            string procedureName = "[getEstados]";
            var result = new List<Estado>();

            try
            {
                using (SqlCommand command = new SqlCommand(procedureName, connString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string estado = reader.GetString(1);

                                Estado tmp = new Estado()
                                {
                                    Id = id,
                                    EstadoTicked = estado
                                };
                                result.Add(tmp);
                            }
                            connString.Close();
                            return new OkObjectResult(result);
                        }
                        else
                        {
                            connString.Close();
                            return new NotFoundObjectResult("No se encontraron estados disponibles");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                connString.Close();
                Console.Write("Se han encontrado los siguientes errores: \n" + ex);
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}
