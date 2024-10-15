using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Tests;

namespace AirlineCompany.Domain.Repositories.ByList;

public class PassengerRepositoryList : IRepository<Passeneger, int>
{
    private static readonly List<Passeneger> _passengres = FileRreader.ReadPassengers("Data/passengers.csv");

    public List<Passeneger> GetAll()
    {
        return _passengres;
    }

    public Passeneger? GetById(int id)
    {
        return _passengres.Find(p => p.IdPassenger == id);
    }

    public void Add(Passeneger newItem)
    {
        _passengres.Add(newItem);
    }

    public bool Delete(int id)
    {
        var passenger = GetById(id);
        
        if (passenger == null) 
            return false;
        
        _passengres.Remove(passenger);
        return true;
    }

    public bool Update(int id, Passeneger newValue)
    {
        var item_id = _passengres.FindIndex(p => p.IdPassenger == id);
        if (item_id == -1)
            return false;
        _passengres[item_id] = newValue;
        return true;
    }
}
