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
        public List<App1Categoria> GetList()
        {

            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = conn;

            connString.Open();

            string procedureName = "[obtenerCategorias]";
            var result = new List<App1Categoria>();
            using (SqlCommand command = new SqlCommand(procedureName,
            connString))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader? reader = command.ExecuteReader())
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
                }
            }
            return result;
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        #endregion
    }
}
