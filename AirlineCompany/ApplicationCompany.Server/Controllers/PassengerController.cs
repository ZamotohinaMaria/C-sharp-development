using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using AirlineCompany.ApplicationServices.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace AirlineCompany.Server.Controllers;

/// <summary>
/// Класс для работы с данными пассажиров из формы
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class PassengerController(IDbRepository<Passeneger, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Вернуть всех пассажиров
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Passeneger>>> Get()
    {
        var passengers =await repository.GetAll();

        if (passengers == null) return NotFound();
        return Ok(passengers);
    }

    /// <summary>
    /// Вернуть пассажира по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Passeneger>> Get(int id)
    {
        var passenger = await repository.GetById(id);

        if (passenger == null)
            return NotFound();

        return Ok(passenger);
    }

    /// <summary>
    /// Добавить пассажира
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PassengerDto item)
    {
        var passenger = mapper.Map<Passeneger>(item);
        await repository.Add(passenger);
        return Ok();
    }

    /// <summary>
    /// Изменить пассажира по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newItem"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] PassengerDto newItem)
    {
        var passenger = mapper.Map<Passeneger>(newItem);
        var checkUpdate = await repository.Update(id, passenger);

        if (!checkUpdate)
            return NotFound();
        return Ok();
    }

    /// <summary>
    /// Удалить пассажира по id
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
