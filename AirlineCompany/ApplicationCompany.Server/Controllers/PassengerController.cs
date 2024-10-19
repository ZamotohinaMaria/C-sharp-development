using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using AirlineCompany.ApplicationServices.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace AirlineCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PassengerController(IRepository<Passeneger, int> repository, IMapper mapper) : ControllerBase
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
    public IActionResult Post([FromBody] PassengerDto item)
    {
        var passenger = mapper.Map<Passeneger>(item);
        repository.Add(passenger);
        return Ok();
    }

    // PUT api/<PassengerController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PassengerDto newItem)
    {
        var passenger = mapper.Map<Passeneger>(newItem);
        passenger.IdFlight = id;
        if (!repository.Update(id, passenger))
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
