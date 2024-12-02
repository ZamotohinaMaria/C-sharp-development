using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Domain.Repositories.DataBase;

/// <summary>
/// Репозиторий полетов
/// </summary>
public class AirFlightRepositoryDb(AirlineCompanyDbContext context): IDbRepository<AirFlight, int>
{
    /// <summary>
    /// Вернуть все полеты
    /// </summary>
    /// <returns>Список элементов класса AirFlight</returns>  
    public async Task<List<AirFlight>> GetAll()
    {
        return await context.AirFlights.Include(v => v.Plane).ToListAsync();
    }

    /// <summary>
    /// Вернуть полет по id
    /// </summary>
    /// <param name="id">айди полета</param>
    /// <returns>Элемент класса AirFlight</returns>
    public async Task<AirFlight?> GetById(int id)
    {
        return await context.AirFlights.FindAsync(id);
    }

    /// <summary>
    /// Добавить полет
    /// </summary>
    /// <param name="newItem"></param>
    public async Task Add(AirFlight newItem)
    {
        await context.AirFlights.AddAsync(newItem);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить полет по id
    /// </summary>
    /// <param name="id">айди полета</param>
    /// <returns>true - удачное удаление, false - во время удаления произошла ошибка</returns>
    public async Task<bool> Delete(int id)
    {
        var flight = await GetById(id);

        if (flight == null)
            return false;

        context.AirFlights.Remove(flight);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Изменить полет по id
    /// </summary>
    /// <param name="id">айди полета</param>
    /// <param name="newValue">Новое значение</param>
    /// <returns>true - удачное изменение, false - во время изменения произошла ошибка</returns>
    public async Task<bool> Update(int id, AirFlight newValue)
    {
        var flight = await GetById(id);
        if (flight == null)
            return false;
        flight.CodeNumber = newValue.CodeNumber;
        flight.DeparturePoint = newValue.DeparturePoint;
        flight.ArrivalPoint = newValue.ArrivalPoint;
        flight.Departure = newValue.Departure;
        flight.Arrive = newValue.Arrive;
        flight.FlyingTime = newValue.FlyingTime;
        flight.PlaneId = newValue.Plane.IdPlane;

        context.AirFlights.Update(flight);
        await context.SaveChangesAsync();

        return true;
    }
}
