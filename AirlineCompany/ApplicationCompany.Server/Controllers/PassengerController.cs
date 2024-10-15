using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using Microsoft.AspNetCore.Mvc;


namespace ApplicationCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PassengerController(IRepository<Passeneger, int> repository) : ControllerBase
{
    // GET: api/<PassengerController>
    [HttpGet]
    public ActionResult<IEnumerable<Passeneger>> Get()
    {
        return Ok(repository.GetAll());
    }

    // GET api/<PassengerController>/5
    [HttpGet("{id}")]
    public ActionResult<Passeneger> Get(int id)
    {
        var passenger = repository.GetById(id);

        if (passenger == null)
            return NotFound();

        return Ok(passenger);
    }

    // POST api/<PassengerController>
    [HttpPost]
    public IActionResult Post([FromBody] Passeneger item)
    {
        repository.Add(item);
        return Ok();
    }

    // PUT api/<PassengerController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Passeneger newItem)
    {
        if (!repository.Update(id, newItem))
            return NotFound();
        return Ok();
    }

    // DELETE api/<PassengerController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id))
            return NotFound();
        return Ok();
    }
}
