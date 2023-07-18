using FlexibleDataApplication.DbContexts;
using FlexibleDataApplication.Repositories;
using FlexibleDataApplication.Services;
using FlexibleDataApplication.Services.Util;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding DbContext
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions
    => dbContextOptions.UseSqlServer(connectionString),ServiceLifetime.Transient);

builder.Services.AddScoped<IFlexibleDataRepository,FlexibleDataRepository>();
builder.Services.AddScoped<IFlexibleDataService, FlexibleDataService>();
builder.Services.AddScoped<IStatisticsDataRepository, StatisticsDataRepository>();
builder.Services.AddSingleton<IStatisticsBackgroundService, StatisticsBackgroundService>();
builder.Services.AddScoped<IStatisticsService, StatisticsService>();
builder.Services.AddHostedService<BackgroundLongRunningService>();
builder.Services.AddSingleton<BackgroundWorkerQueue>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
