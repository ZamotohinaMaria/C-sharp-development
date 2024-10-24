using AirlineCompany.Domain.Models;
using AirlineCompany.ApplicationServices.DTO;
using AutoMapper;
using System.Runtime.CompilerServices;
using AirlineCompany.Domain.Repositories.ByList;
using System.Net.Http.Headers;
using AirlineCompany.Domain.Interfaces;

namespace AirlineCompany.ApplicationServices;

public class AirlineCompaneMapper : Profile
{
    /// <summary>
    /// Метод для преобразования данных с формы в данные в объекты классов
    /// </summary>
    public AirlineCompaneMapper(IRepository<Plane, int> planeRepository)
    {
        CreateMap<AirFlight, AirFlightDto>()
        .ForMember(dest => dest.IdPlaneType, member => member.MapFrom(src => src.Plane.IdPlane))
        .ReverseMap()
        .ForMember(dest => dest.Plane, member => member.MapFrom(src => planeRepository.GetById(src.IdPlaneType)))
        .ForMember(dest => dest.FlyingTime, member => member.MapFrom(src => TimeOnly.FromTimeSpan(src.Arrive - src.Departure)));

        CreateMap<Plane, PlaneDto>().ReverseMap();
        CreateMap<Passeneger, PassengerDto>().ReverseMap();
    }
}
