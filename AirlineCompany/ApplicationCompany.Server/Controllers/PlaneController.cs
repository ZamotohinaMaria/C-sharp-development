using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlaneController(IRepository<Plane, int> repository) : ControllerBase
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
    public IActionResult Post([FromBody] Plane item)
    {
        repository.Add(item);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Plane newItem)
    {
        if (!repository.Update(id, newItem))
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

