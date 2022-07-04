// using Microsoft.AspNetCore.Mvc;
// using TickedWebAPI.Interfaces;
// using TickedWebAPI.Models;

// namespace TickedWebAPI.Services
// {
//     public class PostDataService
//     {
//         private readonly IPostData _postData;

//         public PostDataService(IPostData postData)
//         {
//             _postData = postData;
//         }

//         public Task<IActionResult> InsertarDatos([FromBody] TickedPost ticked)
//         {
//             var res = _postData.PostData(ticked);
//             return res;
//         }
//     }
// }
