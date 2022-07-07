using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Interfaces.Prioridades;
using TickedWebAPI.Models;

namespace TickedWebAPI.Repositories
{
    public class PrioridadRepository : IPrioridadRepository
    {
        private readonly TickedContext tickedContext;
        private readonly IMapper mapper;
        public PrioridadRepository(TickedContext tickedContext, IMapper mapper)
        {
            this.tickedContext = tickedContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<PrioridadDto>> GetAllPrioridades()
        {
            string procedureName = "dbo.GetPrioridades";
            var result = await tickedContext.Prioridades.FromSqlRaw("EXECUTE {0}", procedureName).ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            return mapper.Map<IEnumerable<PrioridadDto>>(result);
        }
    }
}