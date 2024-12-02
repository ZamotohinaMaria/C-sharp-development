using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using AirlineCompany.Domain.Interfaces;
using AirlineCompany.ApplicationServices.DTO;
using System.Runtime.CompilerServices;
using AutoMapper;
using System.Net.Http.Headers;

namespace AirlineCompany.ApplicationServices;

public class AirlineCompaneMapper : Profile
{
    /// <summary>
    /// Метод для преобразования данных с формы в данные в объекты классов
    /// </summary>
    public AirlineCompaneMapper()
    {
        CreateMap<AirFlight, AirFlightDto>().ReverseMap().ForMember(dest => dest.FlyingTime, member => member.MapFrom(src => TimeOnly.FromTimeSpan(src.Arrive - src.Departure)));
        CreateMap<Plane, PlaneDto>().ReverseMap();
        CreateMap<Passeneger, PassengerDto>().ReverseMap();
    }
}
