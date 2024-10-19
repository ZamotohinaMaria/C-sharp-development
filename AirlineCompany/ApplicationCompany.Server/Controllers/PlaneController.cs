using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using AirlineCompany.ApplicationServices.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlaneController(IRepository<Plane, int> repository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Plane>> Get()
    {
        return Ok(repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Plane> Get(int id)
    {
        var plane = repository.GetById(id);

        if (plane == null)
            return NotFound();

        return Ok(plane);
    }

    [HttpPost]
    public IActionResult Post([FromBody] PlaneDto item)
    {
        var plane = mapper.Map<Plane>(item);
        repository.Add(plane);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PlaneDto newItem)
    {
        var plane = mapper.Map<Plane>(newItem);
        plane.IdPlane = id;
        if (!repository.Update(id, plane))
            return NotFound();
        return Ok();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();
        return Ok();
    }
}

