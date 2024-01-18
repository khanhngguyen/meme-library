using Npgsql;
using Microsoft.EntityFrameworkCore;

using MemeLibrary.Infrastructure.src.Database;
using MemeLibrary.Domain.src.RepoInterfaces;
using MemeLibrary.Infrastructure.src.RepoImplementations;

var builder = WebApplication.CreateBuilder(args);

// Add database into the application
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var npgsqlBuilder = new NpgsqlDataSourceBuilder(connectionString);

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(builder => 
    {
        builder.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorCodesToAdd: null
        );
    });
    options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
});


// Add services to the container.
// Services for auto dependency injection
// Repo
builder.Services.AddScoped<IMemeRepo, MemeRepo>();
// Services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config route
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
