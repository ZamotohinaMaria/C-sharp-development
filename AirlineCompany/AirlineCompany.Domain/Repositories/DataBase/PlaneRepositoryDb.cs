using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Domain.Repositories.DataBase;

/// <summary>
/// Репозиторий Самолетов
/// </summary>
public class PlaneRepositoryDb(AirlineCompanyDbContext context) : IDbRepository<Plane, int>
{
    /// <summary>
    /// Вернуть все самолеты
    /// </summary>
    /// <returns>Список элементов класса Plane</returns>
    public async Task<List<Plane>> GetAll()
    {
        return await context.Planes.ToListAsync();
    }

    /// <summary>
    /// Вернуть смолет по id
    /// </summary>
    /// <param name="id">Айди самолета</param>
    /// <returns>Элемент класса Plane</returns>
    public async Task<Plane?> GetById(int id)
    {
        return await context.Planes.FindAsync(id);
    }


    /// <summary>
    /// Добавить самолет
    /// </summary>
    /// <param name="newItem"></param>
    public async Task Add(Plane newItem)
    {
        await context.Planes.AddAsync(newItem);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить самолет по id
    /// </summary>
    /// <param name="id">Айди самолета</param>
    /// <returns>true - удачное удаление, false - во время удаления произошла ошибка</returns>
    public async Task<bool> Delete(int id)
    {
        var plane = await GetById(id);

        if (plane == null)
            return false;

        context.Planes.Remove(plane);
        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Изменить самолет по id
    /// </summary>
    /// <param name="id">Айди самолета</param>
    /// <param name="newValue">Новое значение</param>
    /// <returns>true - удачное изменение, false - во время изменения произошла ошибка</returns>
    public async Task<bool> Update(int id, Plane newValue)
    {
        var plane = await GetById(id);
        if (plane == null)
            return false;
        plane.Model = newValue.Model;
        plane.LoadCapacity = newValue.LoadCapacity;
        plane.Efficiency = newValue.Efficiency;
        plane.PassengerMax = newValue.PassengerMax;

        context.Planes.Update(plane);
        await context.SaveChangesAsync();

        return true;
    }
}
