using Microsoft.EntityFrameworkCore;
using DitchDietsDiary.Infrastructure.Repositories;
using DitchDietsDiary.Core.Interfaces;
using DitchDietsDiary.Infrastructure.Data; 


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddScoped<IFoodLoggingRepository, FoodLoggingRepository>();

// Register the DbContext to use an in-memory database
builder.Services.AddDbContext<FoodLoggingDbContext>(options =>
    options.UseInMemoryDatabase("FoodLoggingDb")); // Use in-memory database

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
