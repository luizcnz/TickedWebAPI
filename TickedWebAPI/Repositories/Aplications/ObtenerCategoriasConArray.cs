using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using TickedWebAPI.Interfaces;
using TickedWebAPI.Models;
using TickedWebAPI.Repositories;
using TickedWebAPI.Utils;

namespace TickedWebAPI.Repositories.Aplications
{
    public class ObtenerCategoriasConArray : IGetData
    {
        private readonly TickedContext _tickedContext;
        public ObtenerCategoriasConArray(TickedContext tickedContext)
        {
            _tickedContext = tickedContext;
        }
        public async Task<IActionResult> GetData()
        {

            string procedureName = "dbo.getCategorias";
            string procedureName2 = "dbo.getCategoriaDetalles";

            try
            {
                var result = await _tickedContext.CategoriasySubcat.FromSqlRaw("exec {0}", procedureName).ToListAsync();
                if (result.Count == 0)
                {
                    return new OkObjectResult("NoResult");
                }
                foreach (CategoriaSubcat c in result)
                {
                    c.detalles = await _tickedContext.Subcategorias.FromSqlRaw("exec {0} @Id = {1}", procedureName2, c.id).ToListAsync();
                }
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                Console.Write("Se han encontrado los siguientes errores: \n" + ex);
                return new OkObjectResult("Error");
            }


            #region codigo funcional (proximo a borrarse)

            //     SqlConnection connString = new SqlConnection();
            //     connString.ConnectionString = ConnectionConf.conn;
            //     connString.Open();

            //     SqlConnection connString2 = new SqlConnection();
            //     connString2.ConnectionString = ConnectionConf.conn;
            //     connString2.Open();

            //     string procedureName = "[getCategorias]";
            //     string procedureName2 = "[getCategoriaDetalles]";
            //     var result = new List<CategoriaSubcat>();
            //     try
            //     {
            //         await using (SqlCommand command = new SqlCommand(procedureName,
            //         connString))
            //         {
            //             command.CommandType = CommandType.StoredProcedure;

            //             using (SqlDataReader? reader = command.ExecuteReader())
            //             {
            //                 if (reader.HasRows)
            //                 {
            //                     while (reader.Read())
            //                     {
            //                         int id = reader.GetIntOrNull(0);
            //                         string? categoria = reader.GetStringOrNull(1);
            //                         bool? estadocat = reader.GetBoolOrNull(2);
            //                         var subcategorias = new List<SubcategoriaDto>();

            //                         // Inicio del codigo para obtener los detalles del ticked
            //                         try
            //                         {
            //                             using (SqlCommand command2 = new SqlCommand(procedureName2,
            //                             connString2))
            //                             {
            //                                 command2.CommandType = CommandType.StoredProcedure;
            //                                 command2.Parameters.Add(new SqlParameter("@NumId", id));
            //                                 using (SqlDataReader? reader2 = command2.ExecuteReader())
            //                                 {
            //                                     if (reader2.HasRows)
            //                                     {
            //                                         while (reader2.Read())
            //                                         {
            //                                             int subId = reader2.GetInt32(0);
            //                                             string subcategoria = reader2.GetString(1);
            //                                             bool estado = reader2.GetBoolean(2);
            //                                             int catId = reader2.GetInt32(3);

            //                                             SubcategoriaDto tmp = new SubcategoriaDto()
            //                                             {
            //                                                 Id = subId,
            //                                                 SubcategoriaTicked = subcategoria,
            //                                                 EstadoSub = estado,
            //                                                 CategoriaId = catId
            //                                             };
            //                                             subcategorias.Add(tmp);
            //                                         }
            //                                     }
            //                                 }
            //                             }
            //                         }
            //                         catch (Exception ex)
            //                         {
            //                             connString.Close();
            //                             connString2.Close();
            //                             Console.Write("Se han encontrado los siguientes errores mientras se obtenian lo detalles: " + ex + "");
            //                             return new OkObjectResult("Error");
            //                         }

            //                         CategoriaSubcat tmpRecord = new CategoriaSubcat()
            //                         {
            //                             Id = id,
            //                             CategoriaTicked = categoria,
            //                             EstadoCat = estadocat,
            //                             Subcategoria = subcategorias
            //                         };
            //                         result.Add(tmpRecord);
            //                     }
            //                     connString.Close();
            //                     return new OkObjectResult(result);
            //                 }
            //                 else
            //                 {
            //                     connString.Close();
            //                     return new OkObjectResult("NoResult");
            //                 }
            //             }
            //         }
            //     }
            //     catch (Exception ex)
            //     {
            //         connString.Close();
            //         Console.Write("Se han encontrado los siguientes errores: \n" + ex);
            //         return new OkObjectResult("Error");
            //     }
            #endregion
        }
    }
}
