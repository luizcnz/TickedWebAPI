using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TickedWebAPI.Interfaces;
using TickedWebAPI.Models;
using TickedWebAPI.Repositories;
using TickedWebAPI.Utils;

namespace TickedWebAPI.Repositories.Aplications
{
    public class ObtenerPrioridades : IGetData
    {

        private readonly TickedContext _tickedContext;
        public ObtenerPrioridades(TickedContext tickedContext)
        {
            _tickedContext = tickedContext;
        }
        public async Task<IActionResult> GetData()
        {
            string procedureName = "dbo.getPrioridades";

            try
            {
                var result = await _tickedContext.Prioridades.FromSqlRaw("EXECUTE {0}", procedureName).ToListAsync();
                
                if (result.Count == 0)
                {
                    return new OkObjectResult("NoResult");
                }
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                Console.Write("Se han capturado los siguientes errores: " + ex);
                return new OkObjectResult("Error");
            }

            #region codigo funcional proximo a eliminarse
            // SqlConnection connString = new SqlConnection();
            // connString.ConnectionString = ConnectionConf.conn;
            // connString.Open();

            // string procedureName = "[getPrioridades]";
            // var result = new List<PrioridadDto>();

            // try
            // {
            //     await using (SqlCommand command = new SqlCommand(procedureName, connString))
            //     {
            //         command.CommandType = CommandType.StoredProcedure;
            //         using (SqlDataReader? reader = command.ExecuteReader())
            //         {
            //             if (reader.HasRows)
            //             {
            //                 while (reader.Read())
            //                 {
            //                     int id = reader.GetInt32(0);
            //                     string prioridad = reader.GetString(1);

            //                     PrioridadDto tmp = new PrioridadDto()
            //                     {
            //                         Id = id,
            //                         PrioridadTicked = prioridad
            //                     };
            //                     result.Add(tmp);
            //                 }
            //                 connString.Close();
            //                 return new OkObjectResult(result);
            //             }
            //             else
            //             {
            //                 connString.Close();
            //                 return new OkObjectResult("NoResult");
            //             }
            //         }
            //     }
            // }
            // catch (Exception ex)
            // {
            //     connString.Close();
            //     Console.Write("Se han encontrado los siguientes errores: \n" + ex);
            //     return new OkObjectResult("Error");
            // }
            #endregion
        }
    }
}
