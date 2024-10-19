using AirlineCompany.Domain.Models;
using AirlineCompany.ApplicationServices.DTO;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace AirlineCompany.ApplicationServices;
public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<AirFlight, AirFlightDto>().ReverseMap();
        CreateMap<Plane, PlaneDto>().ReverseMap();
        CreateMap<Passeneger, PassengerDto>().ReverseMap();
    }
}
