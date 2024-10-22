using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using AirlineCompany.ApplicationServices.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompany.Server.Controllers;

/// <summary>
/// Класс для работы с данными самолетов из формы
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class PlaneController(IRepository<Plane, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Вернуть все самолеты
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<Plane>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Вернуть смолет по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Plane> Get(int id)
    {
        var plane = repository.GetById(id);

        if (plane == null)
            return NotFound();

        return Ok(plane);
    }

    /// <summary>
    /// Добавить самолет
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] PlaneDto item)
    {
        var plane = mapper.Map<Plane>(item);
        repository.Add(plane);
        return Ok();
    }

    /// <summary>
    /// Изменить самолет по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newItem"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PlaneDto newItem)
    {
        var plane = mapper.Map<Plane>(newItem);

        if (!repository.Update(id, plane))
            return NotFound();
        return Ok();
    }

    /// <summary>
    /// Удалить самолет по id
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

