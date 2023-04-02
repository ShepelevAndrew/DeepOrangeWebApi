using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;

namespace DeepOrangeWebApi.BLL.Services.Implementations;

public class TechnologyService : IBaseService<Technology>
{
    private readonly IBaseRepository<Technology> _technologyRepository;

    public TechnologyService(IBaseRepository<Technology> technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }

    public async Task CreateAsync(Technology technology)
    {
        await _technologyRepository.AddAsync(technology);
    }

    public async Task<IEnumerable<Technology>> GetAsync()
    {
        var technologies = await _technologyRepository.GetAllAsync();

        return technologies;
    }

    public async Task<Technology> GetByIdAsync(int id)
    {
        var technology = await _technologyRepository.GetByIdAsync(id);

        return technology;
    }

    public async Task UpdateAsync(Technology technology)
    {
        await _technologyRepository.UpdateAsync(technology);
    }

    public async Task DeleteAsync(int id)
    {
        await _technologyRepository.DeleteAsync(id);
    }
}