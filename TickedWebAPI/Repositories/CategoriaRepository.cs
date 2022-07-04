using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Interfaces.Categorias;
using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly TickedContext tickedContext;
        private readonly IMapper mapper;

        public CategoriaRepository(TickedContext tickedContext, IMapper mapper)
        {
            this.tickedContext = tickedContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDto>> GetAllCategorias()
        {
            string procedureName = "dbo.GetCategorias";

            var result = await tickedContext.Categorias.FromSqlRaw("exec {0}", procedureName).ToListAsync();

            if (result.Count == 0)
            {
                return null;
            }
            IEnumerable<CategoriaDto> categorias = mapper.Map<IEnumerable<CategoriaDto>>(result);

            return categorias;
        }

        public async Task<IEnumerable<CategoriaConSubcategoriasDto>> GetAllCategoriasWithSubcategorias()
        {
            string procedureName = "dbo.GetCategorias";
            string procedureName2 = "dbo.GetCategoriaDetalles";

            var result = await tickedContext.CategoriasConSubcategorias.FromSqlRaw("exec {0}", procedureName).ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            foreach (CategoriaConSubcategoriasModel c in result)
            {
                c.detalles = await tickedContext.Subcategorias.FromSqlRaw("exec {0} @Id = {1}", procedureName2, c.id).ToListAsync();
            }
            IEnumerable<CategoriaConSubcategoriasDto> catSubcat = mapper.Map<IEnumerable<CategoriaConSubcategoriasDto>>(result);

            return catSubcat;
        }
    }
}