using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TickedWebAPI.Interfaces;
using TickedWebAPI.Models;
using TickedWebAPI.Repositories;
using TickedWebAPI.Utils;

namespace TickedWebAPI.Repositories.Aplications
{
    public class ObtenerPrioridades : IGetData
    {
        public async Task<IActionResult> GetData()
        {
            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = ConnectionConf.conn;
            connString.Open();

            string procedureName = "[getPrioridades]";
            var result = new List<PrioridadDto>();

            try
            {
                await using (SqlCommand command = new SqlCommand(procedureName, connString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string prioridad = reader.GetString(1);

                                PrioridadDto tmp = new PrioridadDto()
                                {
                                    Id = id,
                                    PrioridadTicked = prioridad
                                };
                                result.Add(tmp);
                            }
                            connString.Close();
                            return new OkObjectResult(result);
                        }
                        else
                        {
                            connString.Close();
                            return new NotFoundObjectResult("No se encotraron prioridades disponibles");
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
    }
}
