using AirlineCompany.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using AirlineCompany.Server.Services;
using AirlineCompany.Domain.Repositories;
using AirlineCompany.ApplicationServices.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirlineCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController(RequestService repository) : ControllerBase
{
    /// <summary>
    /// 1) Вывести сведения о всех авиарейсах, вылетевших из указанного пункта отправления
    ///  в указанный пункт прибытия.
    /// </summary>
    /// <returns></returns>
    [HttpGet("first")]
    public ActionResult<IEnumerable<AirFlight>> GetFirst(string departure, string arrive)
    {
        return Ok(repository.GetFlyightDepartureArrive(departure, arrive));
    }


    /// <summary>
    /// 2) Вывести сведения обо всех пассажирах, летящих данным рейсом,
    /// вес багажа которых равен нулю, упорядочить по ФИО.
    /// </summary>
    /// <returns></returns>
    [HttpGet("second")]
    public ActionResult<IEnumerable<Passeneger>> GetSecond(int idFlight)
    {
        return Ok(repository.GetPassenegersWeightFlight(idFlight));
    }

    /// <summary>
    /// 3) Вывести сводную информацию обо всех полетах самолетов данного типа
    /// в указанный период времени.
    /// </summary>
    /// <returns></returns>
    [HttpGet("third")]
    public ActionResult<IEnumerable<AirFlight>> GetThird(string planeModel, DateTime departure, DateTime arrive)
    {
        return Ok(repository.GetFlyightPassengersDate(planeModel, departure, arrive ));
    }

    /// <summary>
    /// 4) Вывести топ 5 авиарейсов по количеству перевезённых пассажиров.
    /// </summary>
    /// <returns></returns>
    [HttpGet("fourth")]
    public ActionResult<IEnumerable<AirFlightNumberPassangers>> GetFourth()
    {
        return Ok(repository.GetFlyightTopPassengers());
    }


    /// <summary>
    /// 5) Вывести список рейсов с минимальным временем в пути.
    /// </summary>
    /// <returns></returns>
    [HttpGet("fifth")]
    public ActionResult<IEnumerable<AirFlight>> GetFifth()
    {
        return Ok(repository.GetFlyightMinTime());
    }


    /// <summary>
    /// 6) Вывести информацию о средней и максимальной загрузке авиарейсов
    /// из заданного пункта отправления.
    /// </summary>
    /// <returns></returns>
    [HttpGet("sixth")]
    public ActionResult<IEnumerable<double>> GetSixth()
    {
        return Ok(repository.GetFlyightMaxAvrWeight());
    }
}
