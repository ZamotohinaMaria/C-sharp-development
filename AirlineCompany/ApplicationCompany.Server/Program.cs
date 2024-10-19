using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using AirlineCompany.Domain.Interfaces;

using AutoMapper.Configuration;
using AirlineCompany.ApplicationServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepository<Plane, int>, PlaneRepositoryList>();
builder.Services.AddSingleton<IRepository<AirFlight, int>, AirFlightRepositoryList>();
builder.Services.AddSingleton<IRepository<Passeneger, int>, PassengerRepositoryList>();

builder.Services.AddAutoMapper(typeof(Mapper));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
