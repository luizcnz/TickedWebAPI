using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Interfaces;
using Microsoft.Data.SqlClient;
using TickedWebAPI.Models;
using System.Data;
using TickedWebAPI.Utils;

namespace TickedWebAPI.Repositories.Aplications
{
    public class ObtenerTickedPorId : IGetDataById
    {
        public async Task<IActionResult> GetDataById(int DataId)
        {
            SqlConnection connString = new SqlConnection();
            connString.ConnectionString = ConnectionConf.conn;
            connString.Open();

            SqlConnection connString2 = new SqlConnection();
            connString2.ConnectionString = ConnectionConf.conn;
            connString2.Open();

            string procedureName = "[getTickedsById]";
            string procedureName2 = "[getDetalles]";

            var result = new List<TickedDto>();
            try
            {
                await using (SqlCommand command = new SqlCommand(procedureName, connString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", DataId));

                    using (SqlDataReader? reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int? id = reader.GetInt32(0);
                                string? numero;
                                if (reader.IsDBNull(1))
                                {
                                    numero = "Numero Pendiente";
                                }
                                else
                                {
                                    numero = reader.GetString(1);
                                }
                                string? descripcion = reader.GetStringOrNull(2);
                                string? adjunto = reader.GetStringOrNull(3);
                                string? fechacreado;
                                if (reader.IsDBNull(4))
                                {
                                    fechacreado = "Fecha Pendiente";
                                }
                                else
                                {
                                    fechacreado = Convert.ToString(reader.GetDateTime(4));
                                }
                                string? fechaatendido;
                                if (reader.IsDBNull(5))
                                {
                                    fechaatendido = "Fecha Pendiente";
                                }
                                else
                                {
                                    fechaatendido = Convert.ToString(reader.GetDateTime(5));
                                }
                                string? estadoread = reader.GetStringOrNull(6);
                                string? prioridad = reader.GetStringOrNull(7);
                                string? subcategoria = reader.GetStringOrNull(8);
                                string? usuarioSolicitante = reader.GetStringOrNull(9);
                                var detalles = new List<DetalleTickedDto>();

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
                                                    DateTime detalleFecha = reader2.GetDateTime(0);
                                                    string detalleComentario = reader2.GetString(1);
                                                    string detalleUsuario = reader2.GetString(2);
                                                    string detalleAdjunto = reader2.GetString(3);

                                                    DetalleTickedDto tmp = new DetalleTickedDto()
                                                    {
                                                        Fecha = detalleFecha,
                                                        Comentario = detalleComentario,
                                                        Usuario = detalleUsuario,
                                                        Adjunto = detalleAdjunto
                                                    };
                                                    detalles.Add(tmp);
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

                                TickedDto tmpRecord = new TickedDto()
                                {
                                    Numero = numero,
                                    Descripcion = descripcion,
                                    Adjunto = adjunto,
                                    Fechacreado = fechacreado,
                                    Fechaatendido = fechaatendido,
                                    Estado = estadoread,
                                    Prioridad = prioridad,
                                    Subcategoria = subcategoria,
                                    UsuarioSolicitante = usuarioSolicitante,
                                    Detalles = detalles

                                };
                                result.Add(tmpRecord);
                            }
                            connString.Close();
                            return new OkObjectResult(result);
                            //var response = new HttpResponseMessage();
                            //response.Content = new StringContent();
                            //return Request.CreateResponse<Employee>(HttpStatusCode.OK, emp);
                        }
                        else
                        {
                            connString.Close();
                            return new NotFoundObjectResult("No se encontro ningun ticked con el ID: " + DataId + "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                connString.Close();
                Console.Write("Se ha capturado el siguiente error: " + ex + "");
                return new StatusCodeResult(500);
            }
        }
    }
}
