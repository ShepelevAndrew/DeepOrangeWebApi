using DeepOrangeWebApi.DAL.EF;
using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;

namespace DeepOrangeWebApi.DAL.Repositories.Implementations;

public class TechnologyRepository : ITechnologyRepository
{
    private readonly DbContextApp _dbContextApp;

    public TechnologyRepository(DbContextApp dbContextApp)
    {
        _dbContextApp = dbContextApp;
    }

    public async Task AddAsync(int directionId, Technology technology)
    {
        if (technology == null)
        {
            throw new ArgumentNullException(nameof(technology));
        }

        technology.DirectionId = directionId;

        _dbContextApp.Add(technology);
        await _dbContextApp.SaveChangesAsync();
    }

    public Technology GetByIdAsync(int directionId, int technologyId)
    {
        var technology = _dbContextApp.Technologies.Where(t => t.DirectionId == directionId && t.TechnologyId == technologyId).FirstOrDefault();

        return technology;
    }

    public IEnumerable<Technology> GetTechnologiesForDirection(int directionId)
    {
        var technologies = _dbContextApp.Technologies.Where(t => t.DirectionId == directionId);

        return technologies;
    }

    public async Task UpdateAsync(int directionId, Technology technology)
    {
        if(technology == null)
        {
            throw new ArgumentNullException(nameof(technology));
        }

        technology.DirectionId = directionId;

        _dbContextApp.Update(technology);
        await _dbContextApp.SaveChangesAsync();
    }

    public async Task DeleteAsync(int directionId, int technologyId)
    {
        var technology = _dbContextApp.Technologies.Where(t => t.DirectionId == directionId && t.TechnologyId == technologyId).FirstOrDefault();

        if(technology == null)
        {
            throw new ArgumentNullException(nameof(technology));
        }

        _dbContextApp.Technologies.Remove(technology);
        await _dbContextApp.SaveChangesAsync();
    }
}