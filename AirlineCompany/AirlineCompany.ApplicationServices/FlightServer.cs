using AirlineCompany.ApplicationServices.DTO;
using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories;
using AirlineCompany.Domain.Repositories.ByList;
using AutoMapper;

namespace AirlineCompany.ApplicationServices;

/// <summary>
/// Класс необходим для корректного преобразовния данных с формы в объекты классов
/// </summary>
/// <param name="item"></param>
/// <param name="mapper"></param>
public class FlightServer(AirFlightDto item, IMapper mapper)
{
    /// <summary>
    /// Метод возвращает корректый объект класса "Полеты" со всеми заполненными полями
    /// </summary>
    /// <returns>AirFlights flight</returns>
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
