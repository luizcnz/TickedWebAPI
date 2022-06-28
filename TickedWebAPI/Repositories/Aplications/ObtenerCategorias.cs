using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TickedWebAPI.Interfaces;
using TickedWebAPI.Models;
using TickedWebAPI.Utils;

namespace TickedWebAPI.Repositories.Aplications
{
    public class ObtenerCategorias : IGetData
    {

        private readonly TickedContext _tickedContext;
        public ObtenerCategorias(TickedContext tickedContext)
        {
            _tickedContext = tickedContext;
        }

        public async Task<IActionResult> GetData()
        {
            string procedureName = "dbo.getCategorias";
            try
            {
                var result = await _tickedContext.Categorias.FromSqlRaw("exec {0}", procedureName).ToListAsync();

                if (result.Count == 0)
                {
                    return new OkObjectResult("NoResult");
                }
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                Console.Write("Se han encontrado los siguientes errores: \n" + ex);
                return new OkObjectResult("Error");
            }

            #region codigo funcional(obsoleto proximo a borrarse)
            // SqlConnection _sqlConnection = new SqlConnection();
            // _sqlConnection.ConnectionString = ConnectionConf.conn;

            // _sqlConnection.Open();

            // string procedureName = "[getCategorias]";
            // var result = new List<CategoriaDto>();
            // try
            // {
            //     await using (SqlCommand command = new SqlCommand(procedureName,
            //     _sqlConnection))
            //     {
            //         command.CommandType = CommandType.StoredProcedure;

            //         using (SqlDataReader? reader = command.ExecuteReader())
            //         {
            //             if (reader.HasRows)
            //             {
            //                 while (reader.Read())
            //                 {
            //                     int id = reader.GetIntOrNull(0);
            //                     string? categoria = reader.GetStringOrNull(1);
            //                     bool? estadocat = reader.GetBoolOrNull(2);


            //                     CategoriaDto tmpRecord = new CategoriaDto()
            //                     {
            //                         Id = id,
            //                         CategoriaTicked = categoria,
            //                         EstadoCat = estadocat,
            //                     };
            //                     result.Add(tmpRecord);
            //                 }
            //                 _sqlConnection.Close();
            //                 return new OkObjectResult(result);
            //             }
            //             else
            //             {
            //                 _sqlConnection.Close();
            //                 return new OkObjectResult("NoResult");
            //             }
            //         }
            //     }
            // }
            // catch (Exception ex)
            // {
            //     _sqlConnection.Close();
            //     Console.Write("Se han encontrado los siguientes errores: \n" + ex);
            //     return new OkObjectResult("Error");
            // }
            #endregion
        }

    }
}
