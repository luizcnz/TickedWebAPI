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
    public class PrioridadController : ControllerBase
    {
        private readonly tickedContext context;
        public PrioridadController(tickedContext context)
        {
            this.context = context;
        }

        #region obtener Prioridades
        // GET: api/<PrioridadController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(App1Prioridad))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = ConnectionConf.conn;
            connString.Open();

            string procedureName = "[getPrioridades]";
            var result = new List<App1Prioridad>();

            try
            {
                using (SqlCommand command = new SqlCommand(procedureName, connString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string prioridad = reader.GetString(1);

                                App1Prioridad tmp = new App1Prioridad()
                                {
                                    Id = id,
                                    Prioridad = prioridad
                                };
                                result.Add(tmp);
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
            catch(Exception ex)
            {
                connString.Close();
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}
