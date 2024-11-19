using System.Threading.Tasks;
namespace AirlineCompany.Domain.Interfaces;

/// <summary>
/// Базовый интерфейс репозитория для работы с базой данных
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="Tkey"></typeparam>
public interface IDbRepository<TEntity, Tkey>
{
    /// <summary>
    /// Вернуть все элементы коллекции
    /// </summary>
    /// <returns></returns>
    public Task<List<TEntity>> GetAll();

    /// <summary>
    /// Вернуть элемент коллекции по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<TEntity?> GetById(Tkey id);


    /// <summary>
    /// Добавить элемент в коллекцию
    /// </summary>
    /// <param name="newItem"></param>
    public Task Add(TEntity newItem);

    /// <summary>
    /// Удалить элемент из коллекции по id
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public Task<bool> Delete(Tkey key);

    /// <summary>
    /// Изменить объект коллекции по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public Task<bool> Update(Tkey id, TEntity newValue);
}

