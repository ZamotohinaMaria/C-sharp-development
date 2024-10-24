using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using System.Collections.Generic;

namespace AirlineCompany.Domain.Repositories.ByList;

/// <summary>
/// Репозиторий Самолетов
/// </summary>
public class PlaneRepositoryList(): IRepository<Plane, int>
{
    private static readonly List<Plane> _planes = FileRreader.ReadPlanes("Data/planes.csv");
    private static int _countPlanes = _planes.Count;

    /// <summary>
    /// Вернуть все самолеты
    /// </summary>
    /// <returns>Список элементов класса Plane</returns>
    public List<Plane> GetAll()
    {
        return _planes;
    }

    /// <summary>
    /// Вернуть смолет по id
    /// </summary>
    /// <param name="id">Айди самолета</param>
    /// <returns>Элемент класса Plane</returns>
    public Plane? GetById(int id)
    {
        return _planes.Find(p => p.IdPlane == id);
    }


    /// <summary>
    /// Добавить самолет
    /// </summary>
    /// <param name="newItem"></param>
    public void Add(Plane newItem)
    {
        newItem.IdPlane = _countPlanes++;
        _planes.Add(newItem);
    }

    /// <summary>
    /// Удалить самолет по id
    /// </summary>
    /// <param name="id">Айди самолета</param>
    /// <returns>true - удачное удаление, false - во время удаления произошла ошибка</returns>
    public bool Delete(int id)
    {
        var plane = GetById(id);

        if (plane == null)
            return false;

        _planes.Remove(plane);
        return true;
    }

    /// <summary>
    /// Изменить самолет по id
    /// </summary>
    /// <param name="id">Айди самолета</param>
    /// <param name="newValue">Новое значение</param>
    /// <returns>true - удачное изменение, false - во время изменения произошла ошибка</returns>
    public bool Update(int id, Plane newValue)
    {
        var plane = GetById(id);
        if (plane == null)
            return false;
        plane.Model = newValue.Model;
        plane.LoadCapacity = newValue.LoadCapacity;
        plane.Efficiency = newValue.Efficiency;
        plane.PassengerMax = newValue.PassengerMax;
        return true;
    }
}
