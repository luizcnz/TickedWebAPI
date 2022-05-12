using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private readonly tickedContext context;

        public SubcategoriaController(tickedContext context)
        {
            this.context = context;
        }


        // GET: api/<SubcategoriaController>
        [HttpGet]
        public IEnumerable<App1Subcategoria> Get()
        {
            return context.App1Subcategoria.ToList();
        }

        [HttpGet("{id}")]
        public IEnumerable<App1Subcategoria> Get(int id)
        {
            var producto = context.App1Subcategoria.Where(p => p.CategoriaId == id);
            return producto;
        }

    }
}
