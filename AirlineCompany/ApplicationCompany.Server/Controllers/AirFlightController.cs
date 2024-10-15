using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AirFlightController(IRepository<AirFlight, int> repository) : ControllerBase
{
    // GET: api/<AirFlightController>
    [HttpGet]
    public ActionResult<IEnumerable<AirFlight>> Get()
    {
        return Ok(repository.GetAll());
    }

    // GET api/<AirFlightController>/5
    [HttpGet("{id}")]
    public ActionResult<AirFlight> Get(int id)
    {
        var flight = repository.GetById(id);

        if (flight == null)
            return NotFound();

        return Ok(flight);
    }

    // POST api/<AirFlightController>
    [HttpPost]
    public IActionResult Post([FromBody] AirFlight item)
    {
        repository.Add(item);
        return Ok();
    }

    // PUT api/<AirFlightController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AirFlight newItem)
    {
        if (!repository.Update(id, newItem))
            return NotFound();
        return Ok();
    }

    // DELETE api/<AirFlightController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();
        return Ok();
    }
}
