using AirlineCompany.ApplicationServices;
using AirlineCompany.ApplicationServices.DTO;
using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompany.Server.Controllers;


/// <summary>
/// Класс для работы с данными полетов из формы
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class AirFlightController(IRepository<AirFlight, int> repository, IMapper mapper) : ControllerBase
{

    /// <summary>
    /// Вернуть все полеты
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<AirFlight>> Get()
    {
        return Ok(repository.GetAll());
    }


    /// <summary>
    /// Вернуть полет по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<AirFlight> Get(int id)
    {
        var flight = repository.GetById(id);

        if (flight == null)
            return NotFound();

        return Ok(flight);
    }

    /// <summary>
    /// Добавить полет
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] AirFlightDto item)
    {
        AirlineCompaneMapper service = new();
        var flight = service.GetAirFlight(item, mapper);
        repository.Add(flight);
        return Ok();
    }

    /// <summary>
    /// Изменить полет по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newItem"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AirFlightDto newItem)
    {
        AirlineCompaneMapper service = new();

        var flight = service.GetAirFlight(newItem, mapper);

        if (!repository.Update(id, flight))
            return NotFound();
        return Ok();
    }

    /// <summary>
    /// Удалить полет по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();
        return Ok();
    }
}
