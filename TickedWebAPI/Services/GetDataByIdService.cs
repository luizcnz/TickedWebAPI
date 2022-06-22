using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Interfaces;

namespace TickedWebAPI.Services
{
    internal class GetDataByIdService
    {
        private readonly IGetDataById _getDataById;

        public GetDataByIdService(IGetDataById getDataById)
        {
            _getDataById = getDataById;
        }

        public Task<IActionResult> ObtenerDatosPorId(int DataId)
        {
            var res = _getDataById.GetDataById(DataId);
            return res;
        }
    }
}
