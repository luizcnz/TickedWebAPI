using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TickedWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly tickedContext context;

        public CategoriaController(tickedContext context)
        {
            this.context = context;
        }

        static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

        public static IConfigurationRoot configuration = builder.Build();

        public string conn = configuration.GetConnectionString("ConnectionString");



        #region obtencion de categorias
        // GET: api/<CategoriaController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(App1Categoria))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {

            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = conn;

            connString.Open();

            string procedureName = "[obtenerCategorias]";
            var result = new List<App1Categoria>();
            try
            {
                using (SqlCommand command = new SqlCommand(procedureName,
                connString))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetIntOrNull(0);
                                string? categoria = reader.GetStringOrNull(1);
                                bool? estadocat = reader.GetBoolOrNull(2);


                                App1Categoria tmpRecord = new App1Categoria()
                                {
                                    Id = id,
                                    Categoria = categoria,
                                    EstadoCat = estadocat,


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
            catch(Exception ex)
            {
                connString.Close();
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}
