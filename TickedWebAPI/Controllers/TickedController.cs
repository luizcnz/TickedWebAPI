using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickedWebAPI.Models;

namespace TickedWebAPI.Controllers
{
    public class TickedController : Controller
    {
        private readonly tickedContext context;

        public TickedController(tickedContext context)
        {
            this.context = context;
        }

        // GET: api/<CategoriaController>
        //[HttpGet]
        //public IEnumerable<App1Ticked> Get()
        //{
        //    return context.App1Tickeds.ToList();
        //}

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public IEnumerable<App1Ticked> Get(int id)
        {
            var producto = context.App1Tickeds.Where(p => p.EstadoId == id);
            return producto;
        }

        //[HttpGet]
        //public IEnumerable<App1Ticked> Get()
        //{
        //    var producto = context.App1Subcategoria.Where(p => p.EstadoId == 1);
        //    return producto;
        //}

    }
}
