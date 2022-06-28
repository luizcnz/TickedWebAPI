// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Data.SqlClient;
// using Microsoft.EntityFrameworkCore;
// using System.Data;
// using TickedWebAPI.Interfaces;
// using TickedWebAPI.Models;
// using TickedWebAPI.Repositories;
// using TickedWebAPI.Utils;

// namespace TickedWebAPI.Repositories.Aplications
// {
//     public class GetDataWithArrayFromDb : IGetDataWithArray
//     {
//         private readonly TickedContext _tickedContext;
//         public GetDataWithArrayFromDb(TickedContext tickedContext)
//         {
//             _tickedContext = tickedContext;
//         }
//         public async Task<IActionResult> GetData(string ProcedureName1, string ProcedureName2)
//         {

//             try
//             {
//                 var result = await _tickedContext.CategoriasySubcat.FromSqlRaw("exec {0}", ProcedureName1).ToListAsync();
//                 foreach (var c in result)
//                 {
//                     c.detalles = await _tickedContext.Subcategorias.FromSqlRaw("exec {0} @categoriaId = {1}", ProcedureName2, c.id).ToListAsync();
//                 }
//                 return new OkObjectResult(result);
//             }
//             catch (Exception ex)
//             {
//                 Console.Write("Se han encontrado los siguientes errores: \n" + ex);
//                 return new OkObjectResult("Error");
//             }

//         }

//         public Task<IActionResult> GetData()
//         {
//             throw new NotImplementedException();
//         }
//     }
// }
