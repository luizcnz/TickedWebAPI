using AutoMapper;
using TickedWebAPI.Models;
using TickedWebAPI.Models.Entities;

namespace TickedWebAPI.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TickedModel, TickedDto>();
            CreateMap<CategoriaModel, CategoriaDto>();
            CreateMap<CategoriaConSubcategoriasModel, CategoriaConSubcategoriasDto>();
            CreateMap<DetalleTickedModel, DetalleTickedDto>();
            CreateMap<EstadoModel, EstadoDto>();
            CreateMap<PrioridadModel, PrioridadDto>();
            CreateMap<SubcategoriaModel, SubcategoriaDto>();
            CreateMap<SubcategoriaConInnerJoinModel, SubcategoriaConInnerJoinDto>();
        }
    }
}
