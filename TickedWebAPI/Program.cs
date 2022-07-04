using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Repositories;
using TickedWebAPI.Features.Tickeds;
using TickedWebAPI.Interfaces.Categorias;
using TickedWebAPI.Features.Categorias;
using TickedWebAPI.Features.Estados;
using TickedWebAPI.Interfaces.Estados;
using TickedWebAPI.Interfaces;
using TickedWebAPI.Features.Prioridades;
using TickedWebAPI.Interfaces.Prioridades;
using TickedWebAPI.Interfaces.Tickeds;
using TickedWebAPI.Features.Subcategorias;
using TickedWebAPI.Interfaces.Subcategorias;
using AutoMapper;
using TickedWebAPI.Automapper;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var MapperConfig = new MapperConfiguration(mapper =>
{
    mapper.AddProfile(new MappingProfile());
});

IMapper mapper = MapperConfig.CreateMapper();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITickedAppService, TickedAppService>()
                .AddScoped<ITickedRepository, TickedRepository>()
                .AddScoped<ICategoriaAppService, CategoriaAppService>()
                .AddScoped<ICategoriaRepository, CategoriaRepository>()
                .AddScoped<IEstadoAppService, EstadoAppService>()
                .AddScoped<IEstadoRepository, EstadoRepository>()
                .AddScoped<IPrioridadAppService, PrioridadAppService>()
                .AddScoped<IPrioridadRepository, PrioridadRepository>()
                .AddScoped<ISubcategoriaAppService, SubcategoriaAppService>()
                .AddScoped<ISubcategoriaRepository, SubcategoriaRepository>()
                .AddScoped<ITickedDataVerify, TickedDataVerify>()
                .AddSingleton(mapper)
                .AddMvc();



builder.Services.AddDbContext<TickedContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
