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
//     public class GetDataFromDb : IGetData
//     {
//         private readonly TickedContext _tickedContext;
//         private readonly IBaseModel _baseModel;
//         public GetDataFromDb(TickedContext tickedContext, IBaseModel baseModel)
//         {
//             _tickedContext = tickedContext;
//             _baseModel = baseModel;
//         }
//         public async Task<IActionResult> GetData(string procedureName, string DbEntity)
//         {
//             switch (DbEntity)
//             {
//                 case "Categorias":
//                     var context = _tickedContext.Categorias;
//                     break;
//                 case "Categorias":
//                     var context = _tickedContext.CategoriasySubcat;
//                     break;
//                 case "Categorias":
//                     var context = _tickedContext.Categorias;
//                     break;
//                 case "Categorias":
//                     var context = _tickedContext.Categorias;
//                     break;
//                 case "Categorias":
//                     var context = _tickedContext.Categorias;
//                     break;
//                 case "Categorias":
//                     var context = _tickedContext.Categorias;
//                     break;
//                 case "Categorias":
//                     var context = _tickedContext.Categorias;
//                     break;
//                 case "Categorias":
//                     var context = _tickedContext.Categorias;
//                     break;

//             }

//             try
//             {
//                 var result = await FromSqlRaw("EXECUTE {0}", procedureName).ToListAsync();

//                 if (result.Count == 0)
//                 {
//                     return new OkObjectResult("NoResult");
//                 }
//                 return new OkObjectResult(result);
//             }
//             catch (Exception ex)
//             {
//                 Console.Write("Se han capturado los siguientes errores: " + ex);
//                 return new OkObjectResult("Error");
//             }

//         }

//         public Task<IActionResult> GetData()
//         {
//             throw new NotImplementedException();
//         }
//     }
// }
