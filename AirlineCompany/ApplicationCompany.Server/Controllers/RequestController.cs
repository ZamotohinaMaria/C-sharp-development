using AirlineCompany.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using AirlineCompany.Server.Services;
using AirlineCompany.Domain.Repositories;
using AirlineCompany.ApplicationServices.DTO;
using AirlineCompany.Domain.Repositories.ByList;
using AirlineCompany.Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirlineCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController(RequestService service) : ControllerBase
{
    /// <summary>
    /// 1) Вывести сведения о всех авиарейсах, вылетевших из указанного пункта отправления
    ///  в указанный пункт прибытия.
    /// </summary>
    /// <returns></returns>
    [HttpGet("FirstTask")]
    public ActionResult<IEnumerable<AirFlight>> GetFlyightDepartureArrive(string departure, string arrive)
    {
        return Ok(service.GetFlyightDepartureArrive(departure, arrive));
    }


    /// <summary>
    /// 2) Вывести сведения обо всех пассажирах, летящих данным рейсом,
    /// вес багажа которых равен нулю, упорядочить по ФИО.
    /// </summary>
    /// <returns></returns>
    [HttpGet("SecondTask")]
    public ActionResult<IEnumerable<Passeneger>> GetPassenegersWeightFlight(int idFlight)
    {
        return Ok(service.GetPassenegersWeightFlight(idFlight));
    }

    /// <summary>
    /// 3) Вывести сводную информацию обо всех полетах самолетов данного типа
    /// в указанный период времени.
    /// </summary>
    /// <returns></returns>
    [HttpGet("ThirdTask")]
    public ActionResult<IEnumerable<AirFlight>> GetFlyightPassengersDate(string planeModel, DateTime departure, DateTime arrive)
    {
        return Ok(service.GetFlyightPassengersDate(planeModel, departure, arrive ));
    }

    /// <summary>
    /// 4) Вывести топ 5 авиарейсов по количеству перевезённых пассажиров.
    /// </summary>
    /// <returns></returns>
    [HttpGet("FourthTask")]
    public ActionResult<IEnumerable<AirFlightNumberPassangers>> GetFlyightTopPassengers()
    {
        return Ok(service.GetFlyightTopPassengers());
    }


    /// <summary>
    /// 5) Вывести список рейсов с минимальным временем в пути.
    /// </summary>
    /// <returns></returns>
    [HttpGet("FifthTask")]
    public ActionResult<IEnumerable<AirFlight>> GetFlyightMinTime()
    {
        return Ok(service.GetFlyightMinTime());
    }


    /// <summary>
    /// 6) Вывести информацию о средней и максимальной загрузке авиарейсов
    /// из заданного пункта отправления.
    /// </summary>
    /// <returns></returns>
    [HttpGet("SixthTask")]
    public ActionResult<IEnumerable<double>> GetFlyightMaxAvrWeight()
    {
        return Ok(service.GetFlyightMaxAvrWeight());
    }
}
