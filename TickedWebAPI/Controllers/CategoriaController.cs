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
    public class CategoriaController : ControllerBase
    {

        private readonly tickedContext context;

        public CategoriaController(tickedContext context)
        {
            this.context = context;
        }

        #region obtencion de categorias
        // GET: api/<CategoriaController>
        [HttpGet("/api/Categoria")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Categoria))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategorias()
        {

            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = ConnectionConf.conn;

            connString.Open();

            string procedureName = "[obtenerCategorias]";
            var result = new List<Categoria>();
            try
            {
                await using (SqlCommand command = new SqlCommand(procedureName,
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


                                Categoria tmpRecord = new Categoria()
                                {
                                    Id = id,
                                    CategoriaTicked = categoria,
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
                            return new NotFoundObjectResult("No se encotraron categorias disponibles");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                connString.Close();
                Console.Write("Se han encontrado los siguientes errores: \n" + ex);
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region obtencion de categorias con arreglo de subcategorias
        // GET: api/<CategoriaController>
        [HttpGet("/api/CategoriaSubcat")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Categoria))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategoriasSubcat()
        {

            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = ConnectionConf.conn;
            connString.Open();

            SqlConnection connString2 = new SqlConnection();
            connString2.ConnectionString = ConnectionConf.conn;
            connString2.Open();

            string procedureName = "[getCategorias]";
            string procedureName2 = "[getCategoriaDetalles]";
            var result = new List<CategoriaSubcat>();
            try
            {
                await using (SqlCommand command = new SqlCommand(procedureName,
                connString))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetIntOrNull(0);
                                string? categoria = reader.GetStringOrNull(1);
                                bool? estadocat = reader.GetBoolOrNull(2);
                                var subcategorias = new List<Subcategoria>();

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
                                                    int subId = reader2.GetInt32(0);
                                                    string subcategoria = reader2.GetString(1);
                                                    bool estado = reader2.GetBoolean(2);
                                                    int catId = reader2.GetInt32(3);

                                                    Subcategoria tmp = new Subcategoria()
                                                    {
                                                        Id = subId,
                                                        SubcategoriaTicked = subcategoria,
                                                        EstadoSub = estado,
                                                        CategoriaId = catId
                                                    };
                                                    subcategorias.Add(tmp);
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

                                CategoriaSubcat tmpRecord = new CategoriaSubcat()
                                {
                                    Id = id,
                                    CategoriaTicked = categoria,
                                    EstadoCat = estadocat,
                                    Subcategoria = subcategorias
                                };
                                result.Add(tmpRecord);
                            }
                            connString.Close();
                            return new OkObjectResult(result);
                        }
                        else
                        {
                            connString.Close();
                            return new NotFoundObjectResult("No se encotraron categorias disponibles");
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
