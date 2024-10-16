﻿using AirlineCompany.Domain.Interfaces;
using AirlineCompany.Domain.Models;
using AirlineCompany.Tests;

namespace AirlineCompany.Domain.Repositories.ByList;

public class PlaneRepositoryList: IRepository<Plane, int>
{
    private static readonly List<Plane> _planes = FileRreader.ReadPlanes("Data/planes.csv");

    public List<Plane> GetAll()
    {
        return _planes;
    }

    public Plane? GetById(int id)
    {
        return _planes.Find(p => p.IdPlane == id);
    }

    public void Add(Plane newItem)
    {
        _planes.Add(newItem);
    }

    public bool Delete(int id)
    {
        var plane = GetById(id);

        if (plane == null)
            return false;

        _planes.Remove(plane);
        return true;
    }

    public bool Update(int id, Plane newValue)
    {
        var item_id = _planes.FindIndex(p => p.IdPlane == id);
        if (item_id == -1)
            return false;
        _planes[item_id] = newValue;
        return true;
    }
}
