using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TickedWebAPI.Interfaces;
using TickedWebAPI.Models;
using TickedWebAPI.Utils;

namespace TickedWebAPI.Repositories.Aplications
{
    public class ObtenerCategorias : IGetData
    {
        public async Task<IActionResult> GetData()
        {
            SqlConnection _sqlConnection = new SqlConnection();
            _sqlConnection.ConnectionString = ConnectionConf.conn;

            _sqlConnection.Open();

            string procedureName = "[getCategorias]";
            var result = new List<CategoriaDto>();
            try
            {
                await using (SqlCommand command = new SqlCommand(procedureName,
                _sqlConnection))
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


                                CategoriaDto tmpRecord = new CategoriaDto()
                                {
                                    Id = id,
                                    CategoriaTicked = categoria,
                                    EstadoCat = estadocat,
                                };
                                result.Add(tmpRecord);
                            }
                            _sqlConnection.Close();
                            return new OkObjectResult(result);
                        }
                        else
                        {
                            _sqlConnection.Close();
                            return new NotFoundObjectResult("No se encotraron categorias disponibles");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _sqlConnection.Close();
                Console.Write("Se han encontrado los siguientes errores: \n" + ex);
                return new StatusCodeResult(500);
            }
        }

    }
}
