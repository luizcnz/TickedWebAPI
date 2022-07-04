using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Interfaces.Subcategorias;
using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Repositories
{
    public class SubcategoriaRepository : ISubcategoriaRepository
    {
        private readonly TickedContext tickedContext;
        private readonly IMapper mapper;

        public SubcategoriaRepository(TickedContext tickedContext, IMapper mapper)
        {
            this.tickedContext = tickedContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SubcategoriaConInnerJoinDto>> GetAllSubcategorias()
        {
            string procedureName = "dbo.GetSubcategorias";

            var result = await tickedContext.SubcategoriasConInnerJoin.FromSqlRaw("EXECUTE {0}", procedureName).ToListAsync();

            if (result.Count == 0)
            {
                return null;
            }
            IEnumerable<SubcategoriaConInnerJoinDto> subcat = mapper.Map<IEnumerable<SubcategoriaConInnerJoinDto>>(result);

            return subcat;
        }

        public async Task<IEnumerable<SubcategoriaConInnerJoinDto>> GetAllSubcategoriasByCategoriaId(int CatId)
        {
            string procedureName = "dbo.GetSubcategoriasById";
            var result = await tickedContext.SubcategoriasConInnerJoin.FromSqlRaw("EXECUTE {0} @Id = {1}", procedureName, CatId).ToListAsync();

            if (result.Count == 0)
            {
                return null;
            }
            IEnumerable<SubcategoriaConInnerJoinDto> subcat = mapper.Map<IEnumerable<SubcategoriaConInnerJoinDto>>(result);

            return subcat;

        }
    }
}