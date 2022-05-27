﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TickedWebAPI.Models;
using TickedWebAPI.Utils;

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

        #region get de categorias sin filtro con llaves foraneas
        // GET: api/<SubcategoriaController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(App1SubcategoriaJoin))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetList()
        {
            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = ConnectionConf.conn;

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

            connString.ConnectionString = ConnectionConf.conn;

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
