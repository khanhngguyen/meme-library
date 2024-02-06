using Microsoft.EntityFrameworkCore;

using MemeLibrary.Application.src.ServiceInterfaces;
using MemeLibrary.Application.src.Services;
using MemeLibrary.Domain.src.RepoInterfaces;
using MemeLibrary.Infrastructure.src.Database;
using MemeLibrary.Infrastructure.src.RepoImplementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// Add database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(connectionString).UseCamelCaseNamingConvention();
});
// Repo
builder.Services.AddScoped<IMemeRepo, MemeRepo>();
// Services
builder.Services.AddScoped<IMemeService, MemeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseStatusCodePagesWithReExecute("/Error");

app.Run();
