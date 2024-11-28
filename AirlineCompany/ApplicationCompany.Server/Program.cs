using AirlineCompany.Domain;
using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.DataBase;
using AirlineCompany.Domain.Interfaces;
using AirlineCompany.ApplicationServices;
using AirlineCompany.Server.Services;

using AutoMapper.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<AirlineCompanyDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbRepository<Plane, int>, PlaneRepositoryDb>();
builder.Services.AddTransient<IDbRepository<AirFlight, int>, AirFlightRepositoryDb>();
builder.Services.AddTransient<IDbRepository<Passeneger, int>, PassengerRepositoryDb>();
builder.Services.AddTransient<RequestService>();

//builder.Services.AddScoped(provider => new MapperConfiguration(config =>
//{
//    config.AddProfile(new AirlineCompaneMapper(provider.GetRequiredService<IDbRepository<Plane, int>>()));
//}).CreateMapper());
builder.Services.AddAutoMapper(typeof(AirlineCompaneMapper));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Airline Company API", Version = "v1" });

    // ¬ключаем XML комментарии (если используютс€)
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
