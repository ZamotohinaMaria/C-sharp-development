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
        newItem.Idflight = _flights.Count;
        _flights.Add(newItem);
    }

    public bool Delete(int id)
    {
        var flight = GetById(id);

        if (flight == null)
            return false;

        for (var i = id + 1; i < _flights.Count; i++)
            _flights[i].Idflight = i - 1;

        _flights.Remove(flight);
        return true;
    }

    public bool Update(int id, AirFlight newValue)
    {
        var item_id = _flights.FindIndex(p => p.Idflight == id);
        if (item_id == -1)
            return false;
        _flights[item_id].Idflight = newValue.Idflight;
        _flights[item_id].CodeNumber = newValue.CodeNumber;
        _flights[item_id].DeparturePoint = newValue.DeparturePoint;
        _flights[item_id].ArrivalPoint = newValue.ArrivalPoint;
        _flights[item_id].Departure = newValue.Departure;
        _flights[item_id].Arrive = newValue.Arrive;
        _flights[item_id].FlyingTime = newValue.FlyingTime;
        _flights[item_id].PlaneType = newValue.PlaneType;
        return true;
    }
}
