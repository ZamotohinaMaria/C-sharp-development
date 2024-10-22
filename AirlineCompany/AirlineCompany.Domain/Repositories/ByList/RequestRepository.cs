using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;

namespace AirlineCompany.Domain.Repositories.ByList;

/// <summary>
/// Класс предоставляет методы, которые реализуют основыне запросы по заданию
/// </summary>
public class RequestRepository
{
    private static readonly List<AirFlight> _flights = FileRreader.ReadAirFlights("Data/airflyights.csv");
    private static readonly List<Passeneger> _passengers = FileRreader.ReadPassengers("Data/passengers.csv");
    private static readonly List<Plane> _planes = FileRreader.ReadPlanes("Data/planes.csv");

    /// <summary>
    /// 1) Вывести сведения о всех авиарейсах, вылетевших из указанного пункта отправления
    ///  в указанный пункт прибытия.
    /// </summary>
    /// <returns>Список элементов класса AirFlight</returns>
    public List<AirFlight> GetFlyightDepartureArrive(string departure, string arrive)
    {
        var flyightDepartureArrive =
            (from fly in _flights
             where fly.DeparturePoint == departure && fly.ArrivalPoint == arrive
             select fly).ToList();
        return flyightDepartureArrive;
    }


    /// <summary>
    /// 2) Вывести сведения обо всех пассажирах, летящих данным рейсом,
    /// вес багажа которых равен нулю, упорядочить по ФИО.
    /// </summary>
    /// <returns>Список элементов класса Passeneger</returns>
    public List<Passeneger> GetPassenegersWeightFlight(int idFlight)
    {
         var passenegersWeightFlight =
            (from pass in _passengers
             orderby pass.FullName descending
             where pass.IdFlight == idFlight && pass.BaggageWeight == 0
             select pass).ToList();

        return passenegersWeightFlight;
    }


    /// <summary>
    /// 3) Вывести сводную информацию обо всех полетах самолетов данного типа
    /// в указанный период времени.
    /// </summary>
    /// <returns>Список элементов класса AirFlight</returns>
    public List<AirFlight> GetFlyightPassengersDate(string planeModel, DateTime departure, DateTime arrive)
    {
        var flyightPassengersDate =
            (from fly in _flights
             where fly.PlaneType.Model == planeModel &&
             fly.Departure >= departure &&
             fly.Departure <= arrive
             select fly).ToList();

        return flyightPassengersDate;
    }


    /// <summary>
    /// 4) Вывести топ 5 авиарейсов по количеству перевезённых пассажиров.
    /// </summary>
    /// <returns>Список элементов класса AirFlightNumberPassangers</returns>
    public List<AirFlightNumberPassangers> GetFlyightTopPassengers()
    {
        var flyightTopPassengers =
            (from fly in _flights
             let c = _passengers.Count(pass => pass.IdFlight == fly.Idflight)
             orderby c descending
             select new
             {
                 Fly = fly,
                 Count = c
             }).Take(5).ToList();

        List<AirFlightNumberPassangers> result = new();

        foreach (var item in flyightTopPassengers)
        {
            result.Add(new AirFlightNumberPassangers
            {
                    Fly = item.Fly,
                    NumberPassengers = item.Count
                }
            );
        }
        return result;
    }


    /// <summary>
    /// 5) Вывести список рейсов с минимальным временем в пути.
    /// </summary>
    /// <returns>Список элементов класса AirFlight</returns>
    public List<AirFlight> GetFlyightMinTime()
    {
        var flyightMinTime =
            (from fly in _flights
             let minTime = _flights.Min(pass => pass.FlyingTime)
             where fly.FlyingTime == minTime
             select fly).ToList();

        return flyightMinTime;
    }


    /// <summary>
    /// 6) Вывести информацию о средней и максимальной загрузке авиарейсов
    /// из заданного пункта отправления.
    /// </summary>
    /// <returns>Список значений double</returns>
    public List<double> GetFlyightMaxAvrWeight()
    {
        var departure = "Rome";

        var flightWeight =
            from fly in _flights
            join pass in _passengers on fly.Idflight equals pass.IdFlight
            where fly.DeparturePoint == departure
            select new
            {
                Fly = fly,
                Bag = pass.BaggageWeight,
            };

        List<double> result = [flightWeight.Max(f => f.Bag), 
                               flightWeight.Average(f => f.Bag)];

        return result;
    }
}
