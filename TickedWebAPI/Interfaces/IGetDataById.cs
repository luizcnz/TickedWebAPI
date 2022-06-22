using Microsoft.AspNetCore.Mvc;

namespace TickedWebAPI.Interfaces
{
    public interface IGetDataById
    {
        public Task<IActionResult> GetDataById(int DataId);
    }
}
