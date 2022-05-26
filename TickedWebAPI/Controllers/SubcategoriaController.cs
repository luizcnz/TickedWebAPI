using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TickedWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private readonly tickedContext context;

        public SubcategoriaController(tickedContext context)
        {
            this.context = context;
        }

        static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

        public static IConfigurationRoot configuration = builder.Build();

        public string conn = configuration.GetConnectionString("ConnectionString");

        #region get de categorias sin filtro
        // GET: api/<SubcategoriaController>
        //[HttpGet]
        //public List<App1Subcategoria> GetList()
        //{

        //    SqlConnection connString = new SqlConnection();

        //    connString.ConnectionString = conn;

        //    connString.Open();

        //    string procedureName = "[obtenerSubCategorias]";
        //    var result = new List<App1Subcategoria>();
        //    using (SqlCommand command = new SqlCommand(procedureName,
        //    connString))
        //    {
        //        command.CommandType = CommandType.StoredProcedure;

        //        using (SqlDataReader? reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                int id = reader.GetIntOrNull(0);
        //                string? subcategoria = reader.GetStringOrNull(1);
        //                int categoriaid = reader.GetIntOrNull(2);
        //                bool? estadosub = reader.GetBoolOrNull(3);


        //                App1Subcategoria tmpRecord = new App1Subcategoria()
        //                {
        //                    Id = id,
        //                    Subcategoria = subcategoria,
        //                    CategoriaId = categoriaid,
        //                    EstadoSub = estadosub,


        //                };
        //                result.Add(tmpRecord);
        //            }
        //        }
        //    }
        //    return result;
        //}
        #endregion

        #region get de subcategorias segun id de categoria
        //[HttpGet("{CatId}")]
        //public List<App1Subcategoria> Get(int CatId)
        //{

        //    SqlConnection connString = new SqlConnection();

        //    connString.ConnectionString = conn;

        //    connString.Open();

        //    string procedureName = "[obtenerSubCategoriasSegunId]";
        //    var result = new List<App1Subcategoria>();

        //    using (SqlCommand command = new SqlCommand(procedureName,
        //    connString))
        //    {
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new SqlParameter("@categoriaId", CatId));
        //        using (SqlDataReader? reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                int id = reader.GetIntOrNull(0);
        //                string? subcategoria = reader.GetStringOrNull(1);
        //                int categoriaid = reader.GetIntOrNull(2);
        //                bool? estadosub = reader.GetBoolOrNull(3);


        //                App1Subcategoria tmpRecord = new App1Subcategoria()
        //                {
        //                    Id = id,
        //                    Subcategoria = subcategoria,
        //                    CategoriaId = categoriaid,
        //                    EstadoSub = estadosub,


        //                };
        //                result.Add(tmpRecord);
        //            }
        //        }
        //    }
        //    return result;
        //}
        #endregion

        #region get de categorias sin filtro con llaves foraneas
        // GET: api/<SubcategoriaController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(App1SubcategoriaJoin))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetList()
        {
            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = conn;

            connString.Open();

            string procedureName = "[getSubCategorias]";
            var result = new List<App1SubcategoriaJoin>();

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
                                string? subcategoria = reader.GetStringOrNull(1);
                                string categoria = reader.GetStringOrNull(2);
                                bool? estadosub = reader.GetBoolOrNull(3);


                                App1SubcategoriaJoin tmpRecord = new App1SubcategoriaJoin()
                                {
                                    Id = id,
                                    Subcategoria = subcategoria,
                                    Categoria = categoria,
                                    EstadoSub = estadosub,


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

        #region get de subcategorias segun id de categoria con llave foranea
        [HttpGet("{CatId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(App1SubcategoriaJoin))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int CatId)
        {

            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = conn;

            connString.Open();

            string procedureName = "[getSubCategoriasSegunId]";
            var result = new List<App1SubcategoriaJoin>();

            try
            {
                using (SqlCommand command = new SqlCommand(procedureName,
                connString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@categoriaId", CatId));
                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetIntOrNull(0);
                                string? subcategoria = reader.GetStringOrNull(1);
                                string categoria = reader.GetStringOrNull(2);
                                bool? estadosub = reader.GetBoolOrNull(3);


                                App1SubcategoriaJoin tmpRecord = new App1SubcategoriaJoin()
                                {
                                    Id = id,
                                    Subcategoria = subcategoria,
                                    Categoria = categoria,
                                    EstadoSub = estadosub,


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
