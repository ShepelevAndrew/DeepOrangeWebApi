using DeepOrangeWebApi.DAL.Entities;

namespace DeepOrangeWebApi.DAL.Repositories.Interfaces;
public interface IBaseRepository<T>
{
    Task AddAsync(T employee);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task UpdateAsync(T customer);
    Task DeleteAsync(int id);
}
