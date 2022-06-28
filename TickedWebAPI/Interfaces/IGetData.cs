using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TickedWebAPI.Interfaces
{
    public interface IGetData
    {
        public Task<IActionResult> GetData();

    }
}
