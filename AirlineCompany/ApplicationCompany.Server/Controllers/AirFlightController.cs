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
public class AirFlightController(IDbRepository<AirFlight, int> repository, IMapper mapper) : ControllerBase
{

    /// <summary>
    /// Вернуть все полеты
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AirFlight>>> Get()
    {
        var flights = await repository.GetAll();

        if (flights == null) return NotFound();
        return Ok();
    }


    /// <summary>
    /// Вернуть полет по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<AirFlight>> Get(int id)
    {
        var flight = await repository.GetById(id);

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
    public async Task<IActionResult> Post([FromBody] AirFlightDto item)
    {
        var flight = mapper.Map<AirFlight>(item);
        await repository.Add(flight);
        return Ok();
    }

    /// <summary>
    /// Изменить полет по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newItem"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] AirFlightDto newItem)
    {
        var flight = mapper.Map<AirFlight>(newItem);
        var checkUpdate = await repository.Update(id, flight);

        if (!checkUpdate)
            return NotFound();
        return Ok();
    }

    /// <summary>
    /// Удалить полет по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var checkDelete = await repository.Delete(id);

        if (!checkDelete)
            return NotFound(); 
        return Ok();
    }
}
