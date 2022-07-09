using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Interfaces.Estados;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Features.Estados
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoAppService estadoAppService;

        public EstadoController(IEstadoAppService estadoAppService)
        {
            this.estadoAppService = estadoAppService;
        }

        // GET: api/<EstadoControllerController>
        [HttpGet]
        public async Task<IActionResult>  GetAllEstados()
        {
            return Ok(await this.estadoAppService.GetAllEstados());
        }
    }
}
