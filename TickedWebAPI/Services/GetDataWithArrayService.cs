using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Interfaces;

namespace TickedWebAPI.Services
{
    internal class GetDataWithArray
    {
        private readonly IGetDataWithArray _getDataWithArray;
        
        public GetDataWithArray(IGetDataWithArray getDataWithArray)
        {
            _getDataWithArray = getDataWithArray;
        }

        public Task<IActionResult> ObtenerDatos()
        {
            var res = _getDataWithArray.GetData();
            return res;
        }
    }
}
