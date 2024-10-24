namespace AirlineCompany.Domain.Interfaces;

/// <summary>
/// Базовый интерфейс репозитория
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="Tkey"></typeparam>
public interface IRepository<TEntity, Tkey>
{
    /// <summary>
    /// Вернуть все элементы коллекции
    /// </summary>
    /// <returns></returns>
    public List<TEntity> GetAll();

    /// <summary>
    /// Вернуть элемент коллекции по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TEntity? GetById(Tkey id);


    /// <summary>
    /// Добавить элемент в коллекцию
    /// </summary>
    /// <param name="newItem"></param>
    public void Add(TEntity newItem);

    /// <summary>
    /// Удалить элемент из коллекции по id
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool Delete(Tkey key);

    /// <summary>
    /// Изменить объект коллекции по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public bool Update(Tkey id, TEntity newValue);
}

