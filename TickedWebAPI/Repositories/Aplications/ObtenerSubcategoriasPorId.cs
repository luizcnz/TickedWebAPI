using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TickedWebAPI.Interfaces;
using TickedWebAPI.Models;
using TickedWebAPI.Utils;

namespace TickedWebAPI.Repositories.Aplications
{
    public class ObtenerSubcategoriasPorId : IGetDataById
    {
        private readonly TickedContext _tickedContext;
        public ObtenerSubcategoriasPorId(TickedContext tickedContext)
        {
            _tickedContext = tickedContext;
        }
        public async Task<IActionResult> GetDataById(int DataId)
        {
            string procedureName = "dbo.getSubcategoriasById";
            try
            {
                var result = await _tickedContext.Subcategorias.FromSqlRaw("EXECUTE {0} @Id = {1}", procedureName, DataId).ToListAsync();

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
            #region codigo funcional(proximo a borrar)
            // SqlConnection connString = new SqlConnection();

            // connString.ConnectionString = ConnectionConf.conn;

            // connString.Open();

            // string procedureName = "[getSubCategoriasSegunId]";
            // var result = new List<SubcategoriaJoin>();

            // try
            // {
            //     await using SqlCommand command = new SqlCommand(procedureName,
            //     connString);
            //     command.CommandType = CommandType.StoredProcedure;
            //     command.Parameters.Add(new SqlParameter("@categoriaId", DataId));
            //     using SqlDataReader? reader = command.ExecuteReader();
            //     if (reader.HasRows)
            //     {
            //         while (reader.Read())
            //         {
            //             int _id = reader.GetIntOrNull(0);
            //             string? subcategoria = reader.GetStringOrNull(1);
            //             string? categoria = reader.GetStringOrNull(2);
            //             bool? estadosub = reader.GetBoolOrNull(3);


            //             SubcategoriaJoin tmpRecord = new SubcategoriaJoin()
            //             {
            //                 id = _id,
            //                 subcategoria = subcategoria,
            //                 categoria = categoria,
            //                 estado_Sub = estadosub,


            //             };
            //             result.Add(tmpRecord);
            //         }
            //         connString.Close();
            //         return new OkObjectResult(result);
            //     }
            //     else
            //     {
            //         connString.Close();
            //         return new OkObjectResult("NoResult");
            //     }
            // }
            // catch (Exception ex)
            // {
            //     connString.Close();
            //     Console.Write("Se han capturado los siguientes errores:\n" + ex);
            //     return new OkObjectResult("Error");
            // }
            #endregion
        }
    }
}
