using Microsoft.AspNetCore.Mvc;

namespace TickedWebAPI.Interfaces
{
    public interface IGetDataWithArray
    {
        public Task<IActionResult> GetData();

    }
}
