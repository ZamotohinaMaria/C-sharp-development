using AirlineCompany.Domain.Models;
using AirlineCompany.ApplicationServices.DTO;
using AutoMapper;
using System.Runtime.CompilerServices;
using AirlineCompany.Domain.Repositories.ByList;
using System.Net.Http.Headers;

namespace AirlineCompany.ApplicationServices;

public class AirlineCompaneMapper : Profile
{
    /// <summary>
    /// Метод для преобразования данных с формы в данные в объекты классов
    /// </summary>
    public AirlineCompaneMapper()
    {
        CreateMap<AirFlight, AirFlightDto>().ReverseMap();
        CreateMap<Plane, PlaneDto>().ReverseMap();
        CreateMap<Passeneger, PassengerDto>().ReverseMap();
    }

    /// <summary>
    /// Метод возвращает корректый объект класса "Полеты" со всеми заполненными полями
    /// </summary>
    /// <returns>AirFlights flight</returns>
    public AirFlight GetAirFlight(AirFlightDto item, IMapper mapper)
    {
        var flight = mapper.Map<AirFlight>(item);

        PlaneRepositoryList planeRepository = new();
        var plane = planeRepository.GetById(item.IdPlaneType);

        if (plane == null )
            flight.PlaneType = new Plane { IdPlane = item.IdPlaneType, Efficiency = 0, LoadCapacity = 0, Model = "none", PassengerMax = 0};
        else
        {
            flight.PlaneType.IdPlane = plane.IdPlane;
            flight.PlaneType.Efficiency = plane.Efficiency;
            flight.PlaneType.LoadCapacity = plane.LoadCapacity;
            flight.PlaneType.Model = plane.Model;
            flight.PlaneType.PassengerMax = plane.PassengerMax;
        }
    
        flight.FlyingTime = TimeOnly.FromTimeSpan(item.Arrive - item.Departure);
        return flight;
    }
}
