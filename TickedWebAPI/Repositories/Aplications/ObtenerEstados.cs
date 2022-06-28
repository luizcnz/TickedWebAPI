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
    public class ObtenerEstados : IGetData
    {
        private readonly TickedContext _tickedContext;
        public ObtenerEstados(TickedContext tickedContext)
        {
            _tickedContext = tickedContext;
        }
        public async Task<IActionResult> GetData()
        {
            string procedureName = "dbo.getEstados";

            try
            {
                var result = await _tickedContext.Estados.FromSqlRaw("EXECUTE {0}", procedureName).ToListAsync();
                
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

            #region codigo funcional
            // var result = new List<EstadoDto>();
            // SqlConnection _sqlConnection = new SqlConnection();
            // _sqlConnection.ConnectionString = ConnectionConf.conn;
            // _sqlConnection.Open();
            // try
            // {
            //     await using (SqlCommand command = new SqlCommand(procedureName, _sqlConnection))
            //     {
            //        command.CommandType = CommandType.StoredProcedure;
            //        using (SqlDataReader? reader = command.ExecuteReader())
            //        {
            //            if (reader.HasRows)
            //            {
            //                while (reader.Read())
            //                {
            //                    int id = reader.GetInt32(0);
            //                    string estado = reader.GetString(1);

            //                    EstadoDto tmp = new EstadoDto()
            //                    {
            //                        Id = id,
            //                        EstadoTicked = estado
            //                    };
            //                    result.Add(tmp);
            //                }
            //                _sqlConnection.Close();
            //                var data = new OkObjectResult(result);

            //                return data;
            //            }
            //            else
            //            {
            //                _sqlConnection.Close();
            //                return new OkObjectResult("NoResult");
            //            }
            //        }
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
