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
    public async Task<ActionResult<IEnumerable<AirFlight>>> GetFlyightDepartureArrive(string departure, string arrive)
    {
        var res = await service.GetFlyightDepartureArrive(departure, arrive);
        return Ok(res);
    }


    /// <summary>
    /// 2) Вывести сведения обо всех пассажирах, летящих данным рейсом,
    /// вес багажа которых равен нулю, упорядочить по ФИО.
    /// </summary>
    /// <returns></returns>
    [HttpGet("SecondTask")]
    public async Task<ActionResult<IEnumerable<Passeneger>>> GetPassenegersWeightFlight(int idFlight)
    {
        var res = await service.GetPassenegersWeightFlight(idFlight);
        return Ok(res);
    }

    /// <summary>
    /// 3) Вывести сводную информацию обо всех полетах самолетов данного типа
    /// в указанный период времени.
    /// </summary>
    /// <returns></returns>
    [HttpGet("ThirdTask")]
    public async Task<ActionResult<IEnumerable<AirFlight>>> GetFlyightPassengersDate(string planeModel, DateTime departure, DateTime arrive)
    {
        var res = await service.GetFlyightPassengersDate(planeModel, departure, arrive);
        return Ok(res);
    }

    /// <summary>
    /// 4) Вывести топ 5 авиарейсов по количеству перевезённых пассажиров.
    /// </summary>
    /// <returns></returns>
    [HttpGet("FourthTask")]
    public async Task<ActionResult<IEnumerable<AirFlightNumberPassangers>>> GetFlyightTopPassengers()
    {
        var res = await service.GetFlyightTopPassengers();
        return Ok(res);
    }


    /// <summary>
    /// 5) Вывести список рейсов с минимальным временем в пути.
    /// </summary>
    /// <returns></returns>
    [HttpGet("FifthTask")]
    public async Task<ActionResult<IEnumerable<AirFlight>>> GetFlyightMinTime()
    {
        var res = await service.GetFlyightMinTime();
        return Ok(res);
    }


    /// <summary>
    /// 6) Вывести информацию о средней и максимальной загрузке авиарейсов
    /// из заданного пункта отправления.
    /// </summary>
    /// <returns></returns>
    [HttpGet("SixthTask")]
    public async Task<ActionResult<IEnumerable<double>>> GetFlyightMaxAvrWeight(string departure)
    {
        var res = await service.GetFlyightMaxAvrWeight(departure);
        return Ok(res);
    }
}
