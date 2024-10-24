using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using AirlineCompany.Domain.Interfaces;

using AutoMapper.Configuration;
using AirlineCompany.ApplicationServices;
using Microsoft.OpenApi.Models;
using System.Reflection;
using AutoMapper;
using AirlineCompany.Server.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepository<Plane, int>, PlaneRepositoryList>();
builder.Services.AddSingleton<IRepository<AirFlight, int>, AirFlightRepositoryList>();
builder.Services.AddSingleton<IRepository<Passeneger, int>, PassengerRepositoryList>();
builder.Services.AddTransient<RequestService>();

builder.Services.AddSingleton(provider => new MapperConfiguration(config =>
{
    config.AddProfile(new AirlineCompaneMapper(provider.GetRequiredService<IRepository<Plane, int>>()));
}).CreateMapper());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Airline Company API", Version = "v1" });

    // �������� XML ����������� (���� ������������)
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
