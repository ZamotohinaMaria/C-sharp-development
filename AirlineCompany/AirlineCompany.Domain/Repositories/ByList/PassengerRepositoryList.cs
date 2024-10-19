using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Tests;

namespace AirlineCompany.Domain.Repositories.ByList;

/// <summary>
/// Репозиторий Пассажиров
/// </summary>
public class PassengerRepositoryList : IRepository<Passeneger, int>
{
    private static readonly List<Passeneger> _passengres = FileRreader.ReadPassengers("Data/passengers.csv");

    /// <summary>
    /// Вернуть всех пассажиров
    /// </summary>
    /// <returns></returns>
    public List<Passeneger> GetAll()
    {
        return _passengres;
    }

    /// <summary>
    /// Вернуть пассажира по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Passeneger? GetById(int id)
    {
        return _passengres.Find(p => p.IdPassenger == id);
    }

    /// <summary>
    /// Добавить пассажира
    /// </summary>
    /// <param name="newItem"></param>
    public void Add(Passeneger newItem)
    {
        newItem.IdPassenger = _passengres.Count;
        _passengres.Add(newItem);
    }

    /// <summary>
    /// Удалить пассажира по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        var passenger = GetById(id);
        
        if (passenger == null) 
            return false;

        for (var i = id + 1; i < _passengres.Count; i++)
            _passengres[i].IdPassenger = i - 1;

        _passengres.Remove(passenger);
        return true;
    }

    /// <summary>
    /// Изменить пассажира по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public bool Update(int id, Passeneger newValue)
    {
        var item_id = _passengres.FindIndex(p => p.IdPassenger == id);
        if (item_id == -1)
            return false;
        _passengres[item_id].IdFlight = newValue.IdFlight;
        _passengres[item_id].FullName = newValue.FullName;
        _passengres[item_id].Passport = newValue.Passport;
        _passengres[item_id].Registration = newValue.Registration;
        _passengres[item_id].SeatNumber = newValue.SeatNumber;
        _passengres[item_id].BaggageWeight = newValue.BaggageWeight;
        _passengres[item_id].IdFlight = newValue.IdFlight;
        return true;
    }
}
