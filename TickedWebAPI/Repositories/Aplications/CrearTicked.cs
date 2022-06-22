using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TickedWebAPI.Models;
using System.Data;
using TickedWebAPI.Interfaces;


namespace TickedWebAPI.Repositories.Aplications
{
    public class CrearTicked : IPostData
    {
        public async Task<IActionResult> PostData([FromBody] App1TickedPost ticked)
        {
            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = ConnectionConf.conn;

            connString.Open();

            string procedureName = "[postTicked]";

            string? Descripcion = ticked.Descripcion;
            string? Adjunto;
            if(ticked.Adjunto!=null)
            {
                Adjunto = ticked.Adjunto;
            }
            else
            {
                Adjunto = "";
            }
            DateTime? Fechacreado = ticked.Fechacreado;
            int? Prioridad = ticked.PrioridadId;
            int? Subcategoria = ticked.SubcategoriaId;
            int? UsuarioSolicitante = ticked.UsuarioSolicitanteId;
            int id;
            
            try
            {
                await using (SqlCommand command = new SqlCommand(procedureName, connString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    command.Parameters.Add(new SqlParameter("@Adjunto", Adjunto));
                    command.Parameters.Add(new SqlParameter("@Fechacreado", Fechacreado));
                    command.Parameters.Add(new SqlParameter("@Estado", 1));
                    command.Parameters.Add(new SqlParameter("@Prioridad", Prioridad));
                    command.Parameters.Add(new SqlParameter("@Subcategoria", Subcategoria));
                    command.Parameters.Add(new SqlParameter("@UsuarioSolicitante", UsuarioSolicitante));
                    id = (int)command.ExecuteScalar();
                }
                procedureName = "[postTkNumero]";
                await using (SqlCommand command2 = new SqlCommand(procedureName, connString))
                {
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.Add(new SqlParameter("@id", id));
                    command2.ExecuteReader();
                }
                string uri = "http://192.168.0.111:5292/api/Ticked/tickedid/" + id + "";
                connString.Close();

                return new OkObjectResult(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                connString.Close();
                return new OkObjectResult(null);
            }
        }
    }
}
