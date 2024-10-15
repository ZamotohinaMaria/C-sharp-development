namespace AirlineCompany.Domain.Interfaces;
public interface IRepository<TEntity, in Tkey>
{
    public List<TEntity> GetAll();
    public TEntity? GetById(Tkey id);
    public void Add(TEntity newItem);
    public bool Delete(Tkey key);
    public bool Update(Tkey id, TEntity newValue);
}

