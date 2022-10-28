using Microsoft.EntityFrameworkCore;
using Mobflix_backend.Models.Context;
using Mobflix_backend.Repositories;
using Mobflix_backend.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionStringDb = builder.Configuration.GetConnectionString("SbSqlLite");
builder.Services.AddDbContext<MobflixContext>(opt => opt.UseSqlite(connectionStringDb));
builder.Services.AddScoped<IVideoRepository, VideoRepository>();

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

app.Run();
