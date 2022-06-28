using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TickedWebAPI.Models;
using System.Data;
using TickedWebAPI.Utils;
using TickedWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TickedWebAPI.Repositories.Aplications
{
    public class ObtenerTickedsPorIdDeUsuario : IGetDataById
    {
        private readonly TickedContext _tickedContext;
        public ObtenerTickedsPorIdDeUsuario (TickedContext tickedContext)
        {
            _tickedContext = tickedContext;
        }
        public async Task<IActionResult> GetDataById(int DataId)
        {
            string procedureName = "dbo.getTickedsByUserId";
            string procedureName2 = "dbo.getTkDetalles";

            try
            {
                var result = await _tickedContext.Tickeds.FromSqlRaw("exec {0} @Id = {1}", procedureName, DataId).ToListAsync();
                if (result.Count == 0)
                {
                    return new OkObjectResult("NoResult");
                }
                foreach (TickedDto c in result)
                {
                    c.detalles = await _tickedContext.DetalleTickeds.FromSqlRaw("exec {0} @Id = {1}", procedureName2, c.id).ToListAsync();
                }
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                Console.Write("Se han encontrado los siguientes errores: \n" + ex);
                return new OkObjectResult("Error");
            }
            #region proximo a borrar
            // SqlConnection connString = new SqlConnection();
            // connString.ConnectionString = ConnectionConf.conn;
            // connString.Open();

            // SqlConnection connString2 = new SqlConnection();
            // connString2.ConnectionString = ConnectionConf.conn;
            // connString2.Open();

            // string procedureName = "[getTickedsByUserId]";
            // string procedureName2 = "[getDetalles]";

            // var result = new List<TickedDto>();
            // try
            // {
            //     await using (SqlCommand command = new SqlCommand(procedureName, connString))
            //     {
            //         command.CommandType = CommandType.StoredProcedure;
            //         command.Parameters.Add(new SqlParameter("@UserId", DataId));

            //         using (SqlDataReader? reader = command.ExecuteReader())
            //         {
            //             if (reader.HasRows)
            //             {
            //                 while (reader.Read())
            //                 {
            //                     int id = reader.GetInt32(0);
            //                     string? numero;
            //                     if (reader.IsDBNull(1))
            //                     {
            //                         numero = "Numero Pendiente";
            //                     }
            //                     else
            //                     {
            //                         numero = reader.GetString(1);
            //                     }
            //                     string? descripcion = Convert.ToString(reader.GetStringOrNull(2));
            //                     string? adjunto = reader.GetStringOrNull(3);
            //                     string? fechacreado;
            //                     if (reader.IsDBNull(4))
            //                     {
            //                         fechacreado = "Fecha Pendiente";
            //                     }
            //                     else
            //                     {
            //                         fechacreado = Convert.ToString(reader.GetDateTime(4));
            //                     }
            //                     string? fechaatendido;
            //                     if (reader.IsDBNull(5))
            //                     {
            //                         fechaatendido = "Pendiente";
            //                     }
            //                     else
            //                     {
            //                         fechaatendido = Convert.ToString(reader.GetDateTime(5));
            //                     }
            //                     string? estadoread = reader.GetStringOrNull(6);
            //                     string? prioridad = reader.GetStringOrNull(7);
            //                     string? subcategoria = reader.GetStringOrNull(8);
            //                     string? usuarioSolicitante = reader.GetStringOrNull(9);
            //                     var detalles = new List<DetalleTickedDto>();

            //                     // Inicio del codigo para obtener los detalles del ticked
            //                     try
            //                     {
            //                         using (SqlCommand command2 = new SqlCommand(procedureName2,
            //                         connString2))
            //                         {
            //                             command2.CommandType = CommandType.StoredProcedure;
            //                             command2.Parameters.Add(new SqlParameter("@NumId", id));
            //                             using (SqlDataReader? reader2 = command2.ExecuteReader())
            //                             {
            //                                 if (reader2.HasRows)
            //                                 {
            //                                     while (reader2.Read())
            //                                     {
            //                                         DateTime detalleFecha = reader2.GetDateTime(0);
            //                                         string detalleComentario = reader2.GetString(1);
            //                                         string detalleUsuario = reader2.GetString(2);
            //                                         string detalleAdjunto = reader2.GetString(3);

            //                                         DetalleTickedDto tmp = new DetalleTickedDto()
            //                                         {
            //                                             fecha = detalleFecha,
            //                                             comentario = detalleComentario,
            //                                             usuario = detalleUsuario,
            //                                             adjunto = detalleAdjunto
            //                                         };
            //                                         detalles.Add(tmp);
            //                                     }
            //                                 }
            //                             }
            //                         }
            //                     }
            //                     catch (Exception ex)
            //                     {
            //                         connString.Close();
            //                         connString2.Close();
            //                         Console.Write("Se han encontrado los siguientes errores mientras se obtenian lo detalles: " + ex + "");
            //                         return new OkObjectResult(null);
            //                     }


            //                     TickedDto tmpRecord = new TickedDto()
            //                     {
            //                         numero = numero,
            //                         descripcion = descripcion,
            //                         adjunto = adjunto,
            //                         fechacreado = fechacreado,
            //                         fechaAtendido = fechaatendido,
            //                         estado = estadoread,
            //                         prioridad = prioridad,
            //                         subcategoria = subcategoria,
            //                         solicitante = usuarioSolicitante,
            //                         detalles = detalles
            //                     };
            //                     result.Add(tmpRecord);
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
            //     Console.Write("Se ha capturado el siguiente error: " + ex + "");
            //     return new OkObjectResult("Error");
            // }
            #endregion
        }
    }
}
