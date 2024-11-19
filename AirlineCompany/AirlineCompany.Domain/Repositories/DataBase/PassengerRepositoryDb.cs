using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Domain.Repositories.DataBase;

/// <summary>
/// Репозиторий Пассажиров
/// </summary>
public class PassengerRepositoryDb(AirlineCompanyDbContext context) : IDbRepository<Passeneger, int>
{
    /// <summary>
    /// Вернуть всех пассажиров
    /// </summary>
    /// <returns>Список элементов класса Passeneger</returns>
    public async Task<List<Passeneger>> GetAll()
    {
        return await context.Passenegers.ToListAsync();
    }

    /// <summary>
    /// Вернуть пассажира по id
    /// </summary>
    /// <param name="id">Айди пассажира</param>
    /// <returns>Элемент класса Passeneger</returns>
    public async Task<Passeneger?> GetById(int id)
    {
        return await context.Passenegers.FindAsync(id);
    }

    /// <summary>
    /// Добавить пассажира
    /// </summary>
    /// <param name="newItem"></param>
    public async Task Add(Passeneger newItem)
    {
        await context.Passenegers.AddAsync(newItem);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить пассажира по id
    /// </summary>
    /// <param name="id">Айди пассажира</param>
    /// <returns>true - удачное удаление, false - во время удаления произошла ошибка</returns>
    public async Task<bool> Delete(int id)
    {
        var passenger = await GetById(id);

        if (passenger == null)
            return false;

        context.Passenegers.Remove(passenger);
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Изменить пассажира по id
    /// </summary>
    /// <param name="id">Айди пассажира</param>
    /// <param name="newValue">Новое значение</param>
    /// <returns>true - удачное изменение, false - во время изменения произошла ошибка</returns>
    public async Task<bool> Update(int id, Passeneger newValue)
    {
        var pssenger = await GetById(id);
        if (pssenger == null)
            return false;

        pssenger.FullName = newValue.FullName;
        pssenger.Passport = newValue.Passport;
        pssenger.Registration = newValue.Registration;
        pssenger.SeatNumber = newValue.SeatNumber;
        pssenger.BaggageWeight = newValue.BaggageWeight;
        pssenger.IdFlight = newValue.IdFlight;

        context.Passenegers.Update(pssenger);
        await context.SaveChangesAsync();

        return true;
    }
}
