using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TickedWebAPI.Models;

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

        static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        public static IConfigurationRoot configuration = builder.Build();
        public string conn = configuration.GetConnectionString("ConnectionString");

        #region obtener Prioridades
        // GET: api/<EstadoControllerController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(App1Estado))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = conn;
            connString.Open();

            string procedureName = "[getEstados]";
            var result = new List<App1Estado>();

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

                                App1Estado tmp = new App1Estado()
                                {
                                    Id = id,
                                    Estado = estado
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
            catch (Exception ex)
            {
                connString.Close();
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}
