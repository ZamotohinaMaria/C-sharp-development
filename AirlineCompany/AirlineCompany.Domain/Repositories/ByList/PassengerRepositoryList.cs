using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;

namespace AirlineCompany.Domain.Repositories.ByList;

/// <summary>
/// Репозиторий Пассажиров
/// </summary>
public class PassengerRepositoryList : IRepository<Passeneger, int>
{
    private static List<Passeneger> _passengres = FileRreader.ReadPassengers("Data/passengers.csv");
    private static int _countPassengers = _passengres.Count;

    /// <summary>
    /// Вернуть всех пассажиров
    /// </summary>
    /// <returns>Список элементов класса Passeneger</returns>
    public List<Passeneger> GetAll()
    {
        return _passengres;
    }

    /// <summary>
    /// Вернуть пассажира по id
    /// </summary>
    /// <param name="id">Айди пассажира</param>
    /// <returns>Элемент класса Passeneger</returns>
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
        newItem.IdPassenger = _countPassengers++;
        _passengres.Add(newItem);
    }

    /// <summary>
    /// Удалить пассажира по id
    /// </summary>
    /// <param name="id">Айди пассажира</param>
    /// <returns>true - удачное удаление, false - во время удаления произошла ошибка</returns>
    public bool Delete(int id)
    {
        var passenger = GetById(id);
        
        if (passenger == null) 
            return false;

        _passengres.Remove(passenger);
        return true;
    }

    /// <summary>
    /// Изменить пассажира по id
    /// </summary>
    /// <param name="id">Айди пассажира</param>
    /// <param name="newValue">Новое значение</param>
    /// <returns>true - удачное изменение, false - во время изменения произошла ошибка</returns>
    public bool Update(int id, Passeneger newValue)
    {
        var pssenger = GetById(id);
        if (pssenger == null)
            return false;
       pssenger.FullName = newValue.FullName;
       pssenger.Passport = newValue.Passport;
       pssenger.Registration = newValue.Registration;
       pssenger.SeatNumber = newValue.SeatNumber;
       pssenger.BaggageWeight = newValue.BaggageWeight;
       pssenger.IdFlight = newValue.IdFlight;
        return true;
    }
}
