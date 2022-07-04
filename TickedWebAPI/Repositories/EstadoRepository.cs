using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Interfaces.Estados;
using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly TickedContext tickedContext;
        private readonly IMapper mapper;

        public EstadoRepository(TickedContext tickedContext, IMapper mapper)
        {
            this.tickedContext = tickedContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EstadoDto>> GetAllEstados()
        {
            string procedureName = "dbo.GetEstados";

            var result = await tickedContext.Estados.FromSqlRaw("EXECUTE {0}", procedureName).ToListAsync();

            if (result.Count == 0)
            {
                return null;;
            }
            return mapper.Map<IEnumerable<EstadoDto>>(result);

        }

    }
}
