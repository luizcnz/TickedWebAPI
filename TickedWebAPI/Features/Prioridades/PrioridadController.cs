using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Features.Prioridades
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadController : ControllerBase
    {
        private readonly IPrioridadAppService prioridadAppService;

        public PrioridadController(IPrioridadAppService prioridadAppService)
        {
            this.prioridadAppService = prioridadAppService;
        }
        // GET: api/<PrioridadController>
        [HttpGet]
        public async Task<IActionResult> GetAllPrioridades()
        {
            return Ok(await this.prioridadAppService.GetAllPrioridades());
        }
    }
}
