using AirlineCompany.ApplicationServices.DTO;
using AirlineCompany.Domain;
using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AutoMapper;

namespace AirlineCompany.Server.Services;

/// <summary>
/// Класс предоставляет методы, которые реализуют основыне запросы по заданию
/// </summary>
public class RequestService(
    IDbRepository<AirFlight, int> airFlightRepository,
    IDbRepository<Passeneger, int> passengerRepository
    )
{
    /// <summary>
    /// 1) Вывести сведения о всех авиарейсах, вылетевших из указанного пункта отправления
    ///  в указанный пункт прибытия.
    /// </summary>
    /// <returns>Список элементов класса AirFlight</returns>
    public async Task<List<AirFlight>> GetFlyightDepartureArrive(string departure, string arrive)
    {
        var airFlights = await airFlightRepository.GetAll();
        var flyightDepartureArrive =
            (from fly in airFlights
             where fly.DeparturePoint == departure && fly.ArrivalPoint == arrive
             select fly).ToList();
        return flyightDepartureArrive;
    }


    /// <summary>
    /// 2) Вывести сведения обо всех пассажирах, летящих данным рейсом,
    /// вес багажа которых равен нулю, упорядочить по ФИО.
    /// </summary>
    /// <returns>Список элементов класса Passeneger</returns>
    public async Task<List<Passeneger>> GetPassenegersWeightFlight(int idFlight)
    {
        var passengers = await passengerRepository.GetAll();
        var passenegersWeightFlight =
           (from pass in passengers
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
    public async Task<List<AirFlight>> GetFlyightPassengersDate(string planeModel, DateTime departure, DateTime arrive)
    {
        var airFlights = await airFlightRepository.GetAll();

        var flyightPassengersDate =
            (from fly in airFlights
             where fly.Plane.Model == planeModel &&
             fly.Departure >= departure &&
             fly.Departure <= arrive
             select fly).ToList();

        return flyightPassengersDate;
    }


    /// <summary>
    /// 4) Вывести топ 5 авиарейсов по количеству перевезённых пассажиров.
    /// </summary>
    /// <returns>Список элементов класса AirFlightNumberPassangers</returns>
    public async Task<List<AirFlightNumberPassangers>> GetFlyightTopPassengers()
    {
        var passengers = await passengerRepository.GetAll();
        var airFlights = await airFlightRepository.GetAll();

        var flyightTopPassengers =
            (from fly in airFlights
             let c = passengers.Count(pass => pass.IdFlight == fly.Idflight)
             orderby c descending
             select new
             {
                 Fly = fly,
                 Count = c
             }).Take(5).Select(o => new AirFlightNumberPassangers { Fly = o.Fly, NumberPassengers = o.Count}).ToList();

        return flyightTopPassengers;
    }


    /// <summary>
    /// 5) Вывести список рейсов с минимальным временем в пути.
    /// </summary>
    /// <returns>Список элементов класса AirFlight</returns>
    public async Task<List<AirFlight>> GetFlyightMinTime()
    {
        var airFlights = await airFlightRepository.GetAll();

        var flyightMinTime =
            (from fly in airFlights
             let minTime = airFlights.Min(pass => pass.FlyingTime)
             where fly.FlyingTime == minTime
             select fly).ToList();

        return flyightMinTime;
    }


    /// <summary>
    /// 6) Вывести информацию о средней и максимальной загрузке авиарейсов
    /// из заданного пункта отправления.
    /// </summary>
    /// <returns>Список значений double</returns>
    public async Task<List<double>> GetFlyightMaxAvrWeight(string departure)
    {
        var passengers = await passengerRepository.GetAll();
        var airFlights = await airFlightRepository.GetAll();

        var flightWeight =
            from fly in airFlights
            join pass in passengers on fly.Idflight equals pass.IdFlight
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
