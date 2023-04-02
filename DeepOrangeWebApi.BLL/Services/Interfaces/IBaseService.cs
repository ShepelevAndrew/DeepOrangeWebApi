using DeepOrangeWebApi.DAL.Entities;

namespace DeepOrangeWebApi.BLL.Services.Interfaces;
public interface IBaseService<T>
{
    Task CreateAsync(T entity);
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}