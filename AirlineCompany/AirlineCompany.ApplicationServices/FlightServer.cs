using AirlineCompany.ApplicationServices.DTO;
using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories;
using AirlineCompany.Domain.Repositories.ByList;
using AutoMapper;

namespace AirlineCompany.ApplicationServices;
public class FlightServer(AirFlightDto item, IMapper mapper)
{
    public AirFlight GetAirFlight()
    {
        var flight = mapper.Map<AirFlight>(item);

        PlaneRepositoryList planeRepository = new();
        var plane = planeRepository.GetById(item.PlaneId);
        if (plane == null)
            flight.PlaneType = null;
        else
        {
            flight.PlaneType = plane.Model;
            flight.FlyingTime = TimeOnly.FromTimeSpan(item.Arrive - item.Departure);
        }
        return flight;
    }
}
