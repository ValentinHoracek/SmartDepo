using Microsoft.EntityFrameworkCore;
using SmartDepoAPI.Models;
using SmartDepoAPI.Controllers;
using SmartDepoAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase("WeatherForecast"));


builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        policy => policy.WithOrigins([builder.Configuration["BackendUrl"] ?? "http://localhost:5002",
            builder.Configuration["FrontendUrl"] ?? "http://localhost:5001"])
            .AllowAnyMethod()
            .AllowAnyHeader()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    SeedData(context);
}

app.Run();

static void SeedData(AppDbContext context)
{
    context.Depo.AddRange(
        new() { HasSchedule = false, Order = 7, },
        new() { HasSchedule = true, Order = 1, },
        new() { HasSchedule = false, Order = 5, },
        new() { HasSchedule = false, Order = 8, },
        new() { HasSchedule = false, Order = 9, },
        new() { HasSchedule = true, Order = 2, },
        new() { HasSchedule = false, Order = 6, },
        new() { HasSchedule = false, Order = 3, },
        new() { HasSchedule = false, Order = 4, },
        new() { HasSchedule = false, Order = 10, });


    context.SaveChanges();
}