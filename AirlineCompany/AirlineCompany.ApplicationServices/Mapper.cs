using AirlineCompany.Domain.Models;
using AirlineCompany.ApplicationServices.DTO;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace AirlineCompany.ApplicationServices;

public class Mapper : Profile
{
    /// <summary>
    /// Метод для преобразования данных с формы в данные в объекты классов
    /// </summary>
    public Mapper()
    {
        CreateMap<AirFlight, AirFlightDto>().ReverseMap();
        CreateMap<Plane, PlaneDto>().ReverseMap();
        CreateMap<Passeneger, PassengerDto>().ReverseMap();
    }
}
