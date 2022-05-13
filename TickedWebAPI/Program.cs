using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TickedWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connString = builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<tickedContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));

});

//builder.Services.AddControllers()
//            .AddJsonOptions(o => o.JsonSerializerOptions
//                .ReferenceHandler = ReferenceHandler.Preserve);

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
