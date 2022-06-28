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
//     public class GetDataFromDbById : IGetDataById
//     {
//         private readonly TickedContext _tickedContext;
//         public GetDataFromDbById(TickedContext tickedContext)
//         {
//             _tickedContext = tickedContext;
//         } 
//         public async Task<IActionResult> GetDataById(string procedureName ,int DataId)
//         {
//             //string procedureName = "dbo.getPrioridades";
            
//             try
//             {
//                 var result = await _tickedContext.Estados.FromSqlRaw("EXECUTE {0} @Id = {1}", procedureName, DataId).ToListAsync();

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
