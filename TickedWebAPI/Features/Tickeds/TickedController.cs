using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Interfaces.Tickeds;
using TickedWebAPI.Models;

namespace TickedWebAPI.Features.Tickeds
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickedController : ControllerBase
    {
        private readonly ITickedAppService tickedAppService;

        public TickedController(ITickedAppService tickedAppService)
        {
            this.tickedAppService = tickedAppService;
        }


        // GET: api/<TickedController>
        [HttpGet]
        public async Task<IActionResult> GetAllTickedsWithDetails()
        {
            
            return Ok(await this.tickedAppService.GetAllTickedsWithDetails());
        }

        // GET: api/<TickedController>
        [HttpGet("/api/Ticked/userid/{UserId}")]
        public async Task<IActionResult> GetTickedsWithDetailsByUserId(int UserId)
        {
            return Ok(await tickedAppService.GetAllTickedsWithDetailsByUserId(UserId));
        }

        // GET: api/<TickedController>
        [HttpGet("/api/Ticked/tickedid/{TickedId}")]
        public async Task<IActionResult> GetTickedWithDetailsById(int TickedId)
        {
            return Ok(await tickedAppService.GetTickedWithDetailsById(TickedId));
        }

        // POST api/<TickedController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearTickedDto ticked)
        {
            return Ok(await tickedAppService.CreateTicked(ticked));
        }

    }
}

