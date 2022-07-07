using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Interfaces.Tickeds;
using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Repositories
{
    public class TickedRepository : ITickedRepository
    {
        private readonly TickedContext tickedContext;
        private readonly IMapper mapper;
        public TickedRepository(TickedContext tickedContext, IMapper mapper)
        {
            this.tickedContext = tickedContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TickedDto>> GetAllTickedsWithDetails()
        {
            string procedureName = "dbo.GetTickeds";
            string procedureName2 = "dbo.GetTickedDetails";
            var result = await tickedContext.Tickeds.FromSqlRaw("exec {0}", procedureName).ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            foreach (TickedModel ticked in result)
            {
                ticked.detalles = await tickedContext.DetalleTickeds.FromSqlRaw("exec {0} @Id = {1}", procedureName2, ticked.id).ToListAsync();
            }
            return mapper.Map<IEnumerable<TickedDto>>(result);
        }

        public async Task<IEnumerable<TickedDto>> GetAllTickedsWithDetailsByUserId(int UserId)
        {
            string procedureName = "dbo.GetTickedsByUserId";
            string procedureName2 = "dbo.GetTickedDetails";
            var result = await tickedContext.Tickeds.FromSqlRaw("exec {0} @Id = {1}", procedureName, UserId).ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            foreach (TickedModel ticked in result)
            {
                ticked.detalles = await tickedContext.DetalleTickeds.FromSqlRaw("exec {0} @Id = {1}", procedureName2, ticked.id).ToListAsync();
            }
            return mapper.Map<IEnumerable<TickedDto>>(result);
        }

        public async Task<IEnumerable<TickedDto>> GetTickedWithDetailsById(int TickedId)
        {
            string procedureName = "dbo.GetTickedById";
            string procedureName2 = "dbo.GetTickedDetails";
            var result = await tickedContext.Tickeds.FromSqlRaw("exec {0} @Id = {1}", procedureName, TickedId).ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            foreach (TickedModel ticked in result)
            {
                ticked.detalles = await tickedContext.DetalleTickeds.FromSqlRaw("exec {0} @Id = {1}", procedureName2, ticked.id).ToListAsync();
            }
            return mapper.Map<IEnumerable<TickedDto>>(result);
        }

        public async Task<IEnumerable<TickedDto>> CreateTicked(CrearTickedDto ticked)
        {
            string procedureName = "dbo.CreateTicked";
            var result = await tickedContext.Tickeds
                .FromSqlRaw("exec {0} @Descripcion = {1}, @Adjunto = {2}, @Fechacreado = {3}, @Estado = 1, @Prioridad = {4},  @Subcategoria = {5}, @UsuarioSolicitante = {6} "
                , procedureName
                , ticked.Descripcion
                , ticked.Adjunto
                , ticked.Fechacreado
                , ticked.PrioridadId
                , ticked.SubcategoriaId
                , ticked.UsuarioSolicitanteId)
                .ToListAsync();
                tickedContext.SaveChanges();
            return mapper.Map<IEnumerable<TickedDto>>(result);
        }
    }
}