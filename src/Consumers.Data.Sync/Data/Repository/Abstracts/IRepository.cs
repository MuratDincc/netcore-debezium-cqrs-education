using Consumers.Data.Sync.Data.Abstracts;

namespace Consumers.Data.Sync.Data.Repository.Abstracts;

public interface IRepository<T> where T : BaseEntity
{
    List<T> GetAll();
    T GetById(string id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(string id);
}