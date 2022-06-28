using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Interfaces;

namespace TickedWebAPI.Services
{
    internal class GetDataService
    {
        private readonly IGetData _getData;
        
        public GetDataService(IGetData getData)
        {
            _getData = getData;
        }

        public Task<IActionResult> ObtenerDatos()
        {
            var res = _getData.GetData();
            return res;
        }
    }
}
