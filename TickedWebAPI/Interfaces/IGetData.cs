using Microsoft.AspNetCore.Mvc;

namespace TickedWebAPI.Interfaces
{
    public interface IGetData
    {
        public Task<IActionResult> GetData();

    }
}
