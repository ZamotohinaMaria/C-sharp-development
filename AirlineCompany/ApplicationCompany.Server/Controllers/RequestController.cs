using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirlineCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController(RequestRepository repository) : ControllerBase
{
    private readonly RequestRepository _repository;

    /// <summary>
    /// 1) Вывести сведения о всех авиарейсах, вылетевших из указанного пункта отправления
    ///  в указанный пункт прибытия.
    /// </summary>
    /// <returns></returns>
    [HttpGet("first")]
    public ActionResult<IEnumerable<AirFlight>> GetFirst()
    {
        return Ok(repository.GetFlyightDepartureArrive());
    }


    /// <summary>
    /// 2) Вывести сведения обо всех пассажирах, летящих данным рейсом,
    /// вес багажа которых равен нулю, упорядочить по ФИО.
    /// </summary>
    /// <returns></returns>
    [HttpGet("second")]
    public ActionResult<IEnumerable<Passeneger>> GetSecond()
    {
        return Ok(repository.GetPassenegersWeightFlight());
    }

    /// <summary>
    /// 3) Вывести сводную информацию обо всех полетах самолетов данного типа
    /// в указанный период времени.
    /// </summary>
    /// <returns></returns>
    [HttpGet("third")]
    public ActionResult<IEnumerable<AirFlight>> GetThird()
    {
        return Ok(repository.GetFlyightPassengersDate());
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
