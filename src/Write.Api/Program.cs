using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Write.Api.Business;
using Write.Api.Business.Abstracts;
using Write.Api.Data;
using Write.Api.Extensions;
using Write.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = $"Write Api",
        Version = "v1",
    });
    
});

builder.Services.AddScoped<INewsBusiness, NewsBusiness>();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom
});

app.UseMiddleware<DatabaseInstallerMiddleware>();
app.UseStaticFiles();
app.MapControllers();
app.Run();
