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
public class PlaneController(IDbRepository<Plane, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Вернуть все самолеты
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Plane>>> Get()
    {
        var planes = await repository.GetAll();

        if (planes == null) return NotFound();
        return Ok(planes);
    }

    /// <summary>
    /// Вернуть смолет по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Plane>> Get(int id)
    {
        var plane = await repository.GetById(id);

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
    public async Task<IActionResult> Post([FromBody] PlaneDto item)
    {
        var plane = mapper.Map<Plane>(item);
        await repository.Add(plane);
        return Ok();
    }

    /// <summary>
    /// Изменить самолет по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newItem"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] PlaneDto newItem)
    {
        var plane = mapper.Map<Plane>(newItem);
        var checkUpdate = await repository.Update(id, plane);

        if (!checkUpdate)
            return NotFound();
        return Ok();
    }

    /// <summary>
    /// Удалить самолет по id
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

