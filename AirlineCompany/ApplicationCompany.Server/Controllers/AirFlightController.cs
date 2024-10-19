using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Domain.Repositories.ByList;
using AirlineCompany.ApplicationServices.DTO;
using AirlineCompany.Server;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AirlineCompany.ApplicationServices;

namespace AirlineCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AirFlightController(IRepository<AirFlight, int> repository, IMapper mapper) : ControllerBase
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
    public IActionResult Post([FromBody] AirFlightDto item)
    {
        FlightServer service = new(item, mapper);
        var flight = service.GetAirFlight();
        repository.Add(flight);
        return Ok();
    }

    // PUT api/<AirFlightController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AirFlightDto newItem)
    {
        FlightServer service = new(newItem, mapper);

        var flight = service.GetAirFlight();
        flight.Idflight = id;

        if (!repository.Update(id, flight))
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
