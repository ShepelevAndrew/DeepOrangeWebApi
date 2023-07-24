using DeepOrangeWebApi.DAL.EF;
using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeepOrangeWebApi.DAL.Repositories.Implementations;
public class DirectionRepository : IBaseRepository<Direction>
{
    private readonly DbContextApp _dbContextApp;

    public DirectionRepository(DbContextApp dbContextApp)
    {
        _dbContextApp = dbContextApp;
    }

    public async Task AddAsync(Direction direction)
    {
        _dbContextApp.Technologies.AttachRange(direction.Technologies);
        _dbContextApp.Add(direction);
        await _dbContextApp.SaveChangesAsync();
    }

    public async Task<IEnumerable<Direction>> GetAllAsync()
    {
        var directions = await _dbContextApp.Directions.Include(d => d.Technologies).ToListAsync();

        return directions;
    }

    public async Task<Direction> GetByIdAsync(int id)
    {
        var direction = await _dbContextApp.Directions.Include(d => d.Technologies).FirstOrDefaultAsync(d => d.DirectionId == id);

        return direction;
    }

    public async Task UpdateAsync(Direction direction)
    {
        _dbContextApp.Update(direction);
        await _dbContextApp.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var direction = await _dbContextApp.Directions.FindAsync(id);

        _dbContextApp.Directions.Remove(direction);
        await _dbContextApp.SaveChangesAsync();
    }
}
