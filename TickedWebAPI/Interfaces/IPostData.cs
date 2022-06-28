using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Models;

namespace TickedWebAPI.Interfaces
{
    public interface IPostData
    {
        public Task<IActionResult> PostData([FromBody] TickedPost ticked);
        
    }
}
