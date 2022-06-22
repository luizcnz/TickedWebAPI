using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using TickedWebAPI.Interfaces;
using TickedWebAPI.Models;
using TickedWebAPI.Utils;

namespace TickedWebAPI.Repositories.Aplications
{
    public class ObtenerSubcategoriasPorId : IGetDataById
    {
        public async Task<IActionResult> GetDataById(int DataId)
        {

            SqlConnection connString = new SqlConnection();

            connString.ConnectionString = ConnectionConf.conn;

            connString.Open();

            string procedureName = "[getSubCategoriasSegunId]";
            var result = new List<SubcategoriaJoin>();

            try
            {
                await using SqlCommand command = new SqlCommand(procedureName,
                connString);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@categoriaId", DataId));
                using SqlDataReader? reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetIntOrNull(0);
                        string? subcategoria = reader.GetStringOrNull(1);
                        string? categoria = reader.GetStringOrNull(2);
                        bool? estadosub = reader.GetBoolOrNull(3);


                        SubcategoriaJoin tmpRecord = new SubcategoriaJoin()
                        {
                            Id = id,
                            Subcategoria = subcategoria,
                            Categoria = categoria,
                            EstadoSub = estadosub,


                        };
                        result.Add(tmpRecord);
                    }
                    connString.Close();
                    return new OkObjectResult(result);
                }
                else
                {
                    connString.Close();
                    return new NotFoundObjectResult("No se encotraron subcategorias disponibles con el ID: " + DataId + "");
                }
            }
            catch (Exception ex)
            {
                connString.Close();
                Console.Write("Se han capturado los siguientes errores:\n" + ex);
                return new StatusCodeResult(500);
            }
        }
    }
}
