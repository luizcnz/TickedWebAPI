using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickedWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly tickedContext context;

        public CategoriaController(tickedContext context)
        {
            this.context = context;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public IEnumerable<App1Categoria> Get()
        {
            return context.App1Categoria.ToList();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
