using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;

namespace AirlineCompany.Domain.Repositories.ByList;

/// <summary>
/// Репозиторий Полетов
/// </summary>
public class AirFlightRepositoryList : IRepository<AirFlight, int>
{
    private static readonly List<AirFlight> _flights = FileRreader.ReadAirFlights("Data/airflyights.csv");
    private static int  _countFlights = _flights.Count;

    /// <summary>
    /// Вернуть все полеты
    /// </summary>
    /// <returns>Список элементов класса AirFlight</returns>
    public List<AirFlight> GetAll()
    {
        return _flights;
    }

    /// <summary>
    /// Вернуть полет по id
    /// </summary>
    /// <param name="id">айди полета</param>
    /// <returns>Элемент класса AirFlight</returns>
    public AirFlight? GetById(int id)
    {
        return _flights.Find(f => f.Idflight == id);
    }

    /// <summary>
    /// Добавить полет
    /// </summary>
    /// <param name="newItem"></param>
    public void Add(AirFlight newItem)
    {
        newItem.Idflight = _countFlights++;
        _flights.Add(newItem);
    }

    /// <summary>
    /// Удалить полет по id
    /// </summary>
    /// <param name="id">айди полета</param>
    /// <returns>true - удачное удаление, false - во время удаления произошла ошибка</returns>
    public bool Delete(int id)
    {
        var flight = GetById(id);

        if (flight == null)
            return false;

        _flights.Remove(flight);
        return true;
    }

    /// <summary>
    /// Изменить полет по id
    /// </summary>
    /// <param name="id">айди полета</param>
    /// <param name="newValue">Новое значение</param>
    /// <returns>true - удачное изменение, false - во время изменения произошла ошибка</returns>
    public bool Update(int id, AirFlight newValue)
    {
        var flight = GetById(id);
        if (flight == null)
            return false;
        flight.CodeNumber = newValue.CodeNumber;
        flight.DeparturePoint = newValue.DeparturePoint;
        flight.ArrivalPoint = newValue.ArrivalPoint;
        flight.Departure = newValue.Departure;
        flight.Arrive = newValue.Arrive;
        flight.FlyingTime = newValue.FlyingTime;
        flight.Plane = newValue.Plane;
        return true;
    }
}
