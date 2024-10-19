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
public class PassengerController(IRepository<Passeneger, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Вернуть всех пассажиров
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<Passeneger>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Вернуть пассажира по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Passeneger> Get(int id)
    {
        var passenger = repository.GetById(id);

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
    public IActionResult Post([FromBody] PassengerDto item)
    {
        var passenger = mapper.Map<Passeneger>(item);
        repository.Add(passenger);
        return Ok();
    }

    /// <summary>
    /// Удалить пассажира по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newItem"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PassengerDto newItem)
    {
        var passenger = mapper.Map<Passeneger>(newItem);
        passenger.IdFlight = id;
        if (!repository.Update(id, passenger))
            return NotFound();
        return Ok();
    }

    /// <summary>
    /// Изменить пассажира по id
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
