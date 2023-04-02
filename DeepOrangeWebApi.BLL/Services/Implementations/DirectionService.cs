using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;

namespace DeepOrangeWebApi.BLL.Services.Implementations;

public class DirectionService : IBaseService<Direction>
{
    private readonly IBaseRepository<Direction> _directionRepository;

    public DirectionService(IBaseRepository<Direction> directionRepository)
    {
        _directionRepository = directionRepository;
    }

    public async Task CreateAsync(Direction direction)
    {
        await _directionRepository.AddAsync(direction);
    }

    public async Task<IEnumerable<Direction>> GetAsync()
    {
        var directions = await _directionRepository.GetAllAsync();
        return directions;
    }

    public async Task<Direction> GetByIdAsync(int id)
    {
        var direction = await _directionRepository.GetByIdAsync(id);
        return direction;
    }

    public async Task UpdateAsync(Direction direction)
    {
        direction.Technologies = null;

        await _directionRepository.UpdateAsync(direction);
    }

    public async Task DeleteAsync(int id)
    {
        await _directionRepository.DeleteAsync(id);
    }
}
