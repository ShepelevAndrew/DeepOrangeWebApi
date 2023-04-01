namespace DeepOrangeWebApi.DAL.Repositories.Interfaces;
public interface IBaseRepository<T>
{
    void Add(T customer);
    void Update(T customer);
    void Delete(int id);
    Task<IEnumerable<T>> GetAllAsync();
    T GetById(int id);
}
