using API.Catalog.Extensions;
using API.Catalog.Infrastructure.Database;
using Carter;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using poc.core.api.net8;
using poc.core.api.net8.DistributedCache;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Swagger
builder.Services.AddControllers();
builder.Services.AddConnections();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig(builder.Configuration);
builder.Services.UseAuthentication(builder.Configuration);

builder.Services.AddDbContext<EFSqlServerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

DistributedCacheInitializer.Initialize(builder.Services, builder.Configuration);
CoreInitializer.Initialize(builder.Services);

builder.Services.AddCarter();

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddAuthorization();

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(builder.Configuration);
});


var app = builder.Build();

if (app.Environment.IsEnvironment("Test") ||
    app.Environment.IsDevelopment() ||
    app.Environment.IsEnvironment("Docker") ||
    app.Environment.IsStaging() ||
    app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapCarter();

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();


await app.MigrateAsync(); // Aqui faz migrations

app.Run();

public partial class Program { }
