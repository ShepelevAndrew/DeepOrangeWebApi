namespace DeepOrangeWebApi.BLL.Services.Interfaces;

public interface IServiceBase<CrDto, ReDto>
{
    Task CreateAsync(CrDto entity);
    Task<IEnumerable<ReDto>> GetAsync();
    Task<ReDto> GetByIdAsync(int id);
    Task UpdateAsync(CrDto entity);
    Task DeleteAsync(int id);
}