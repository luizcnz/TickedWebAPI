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

        #region get de categorias sin filtro
        // GET: api/<SubcategoriaController>
        //[HttpGet]
        //public List<App1Subcategoria> GetList()
        //{

        //    SqlConnection connString = new SqlConnection();

        //    connString.ConnectionString = @"Server =localhost; Database = ticked; Trusted_Connection = True;";

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

        //    connString.ConnectionString = @"Server =localhost; Database = ticked; Trusted_Connection = True;";

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


        #region get de categorias sin filtro con Join
        // GET: api/<SubcategoriaController>
        [HttpGet]
        public List<App1SubcategoriaJoin> GetList()
        {

            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = @"Server =localhost; Database = ticked; Trusted_Connection = True;";

            connString.Open();

            string procedureName = "[getSubCategorias]";
            var result = new List<App1SubcategoriaJoin>();
            using (SqlCommand command = new SqlCommand(procedureName,
            connString))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader? reader = command.ExecuteReader())
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
                }
            }
            return result;
        }
        #endregion

        #region get de subcategorias segun id de categoria
        [HttpGet("{CatId}")]
        public List<App1SubcategoriaJoin> Get(int CatId)
        {

            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = @"Server =localhost; Database = ticked; Trusted_Connection = True;";

            connString.Open();

            string procedureName = "[getSubCategoriasSegunId]";
            var result = new List<App1SubcategoriaJoin>();

            using (SqlCommand command = new SqlCommand(procedureName,
            connString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@categoriaId", CatId));
                using (SqlDataReader? reader = command.ExecuteReader())
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
                }
            }
            return result;
        }
        #endregion

    }
}
