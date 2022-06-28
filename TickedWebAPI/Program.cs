using Microsoft.EntityFrameworkCore;
using TickedWebAPI.Repositories.Aplications;
using TickedWebAPI.Interfaces;
using TickedWebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGetData, ObtenerEstados>()
                .AddScoped<IGetData, ObtenerCategorias>()
                .AddScoped<IGetData, ObtenerCategoriasConArray>()
                .AddScoped<IGetData, ObtenerPrioridades>()
                .AddScoped<IGetData, ObtenerSubcategorias>()
                .AddScoped<IGetDataById, ObtenerSubcategoriasPorId>()
                .AddScoped<IGetDataById, ObtenerTickedPorId>()
                .AddScoped<IGetData, ObtenerTickeds>()
                .AddScoped<IGetDataById, ObtenerTickedsPorIdDeUsuario>()
                .AddScoped<IPostData, CrearTicked>();

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
