using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Interfaces.Categorias;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Features.Categorias
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppService categoriaAppService;

        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            this.categoriaAppService = categoriaAppService;
        }

        // GET: api/<CategoriaController>
        [HttpGet("/api/Categoria")]
        public async Task<IActionResult>  GetAllCategorias()
        {
            return Ok(await this.categoriaAppService.GetAllCategorias());
        }
        
        //GET: api/<CategoriaController>
        [HttpGet("/api/CategoriaWithSubcategorias")]
        public async Task<IActionResult> GetAllCategoriasWithSubcategorias()
        { 
            return Ok(await this.categoriaAppService.GetAllCategoriasWithSubcategorias());
        }

    }
}
