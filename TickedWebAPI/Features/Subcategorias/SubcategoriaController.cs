using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Features.Subcategorias
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private readonly ISubcategoriaAppService subcategoriaAppService;

        public SubcategoriaController(ISubcategoriaAppService subcategoriaAppService)
        {
            this.subcategoriaAppService = subcategoriaAppService;
        }

        // GET: api/<SubcategoriaController>
        [HttpGet]
        public async Task<IActionResult> GetAllSubcategorias()
        {
            return Ok(await this.subcategoriaAppService.GetAllSubcategorias());
        }

        [HttpGet("{CatId}")]
        public async Task<IActionResult> GetAllSubcategoriasByCategoriaId(int CatId)
        {
            return Ok(await this.subcategoriaAppService.GetAllSubcategoriasByCategoriaId(CatId));
        }
    }
}
