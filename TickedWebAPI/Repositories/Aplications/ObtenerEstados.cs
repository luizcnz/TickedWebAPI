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

        private readonly SqlConnection _sqlConnection;

        public ObtenerEstados(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<IActionResult> GetData()
        {
            string procedureName = "[getEstados]";
            var result = new List<EstadoDto>();
            
            _sqlConnection.ConnectionString = ConnectionConf.conn;
            _sqlConnection.Open();
            try
            {
                await using (SqlCommand command = new SqlCommand(procedureName, _sqlConnection))
                {
                   command.CommandType = CommandType.StoredProcedure;
                   using (SqlDataReader? reader = command.ExecuteReader())
                   {
                       if (reader.HasRows)
                       {
                           while (reader.Read())
                           {
                               int id = reader.GetInt32(0);
                               string estado = reader.GetString(1);

                               EstadoDto tmp = new EstadoDto()
                               {
                                   Id = id,
                                   EstadoTicked = estado
                               };
                               result.Add(tmp);
                           }
                           _sqlConnection.Close();
                           var data = new OkObjectResult(result);

                           return data;
                       }
                       else
                       {
                           _sqlConnection.Close();
                           return new NotFoundObjectResult("No se encontraron estados disponibles");
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
