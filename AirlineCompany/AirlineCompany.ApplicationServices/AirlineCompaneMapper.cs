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
    //IDbRepository<Plane, int> planeRepository
    {
        //CreateMap<AirFlight, AirFlightDto>()
        //.ForMember(dest => dest.IdPlane, member => member.MapFrom(src => src.Plane.IdPlane))
        //.ReverseMap()
        //.ForMember(dest => dest.Plane, member => member.MapFrom(src => planeRepository.GetById(src.IdPlane)))
        //.ForMember(dest => dest.FlyingTime, member => member.MapFrom(src => TimeOnly.FromTimeSpan(src.Arrive - src.Departure)));
        CreateMap<AirFlight, AirFlightDto>().ReverseMap();
        CreateMap<Plane, PlaneDto>().ReverseMap();
        CreateMap<Passeneger, PassengerDto>().ReverseMap();
    }
}
