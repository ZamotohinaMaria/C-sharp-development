using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Tests;

namespace AirlineCompany.Domain.Repositories.ByList;

public class AirFlightRepositoryList : IRepository<AirFlight, int>
{
    private static readonly List<AirFlight> _flights = FileRreader.ReadAirFlights("Data/airflyights.csv");

    public List<AirFlight> GetAll()
    {
        return _flights;
    }

    public AirFlight? GetById(int id)
    {
        return _flights.Find(f => f.Idflight == id);
    }

    public void Add(AirFlight newItem)
    {
        _flights.Add(newItem);
    }

    public bool Delete(int id)
    {
        var flight = GetById(id);

        if (flight == null)
            return false;

        _flights.Remove(flight);
        return true;
    }

    public bool Update(int id, AirFlight newValue)
    {
        var item_id = _flights.FindIndex(p => p.Idflight == id);
        if (item_id == -1)
            return false;
        _flights[item_id] = newValue;
        return true;
    }
}
