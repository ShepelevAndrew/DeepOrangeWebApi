using DeepOrangeWebApi.DAL.EF;
using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeepOrangeWebApi.DAL.Repositories.Implementations;

public class TechnologyRepository : IBaseRepository<Technology>
{
    private readonly DbContextApp _dbContextApp;

    public TechnologyRepository(DbContextApp dbContextApp)
    {
        _dbContextApp = dbContextApp;
    }

    public async Task AddAsync(Technology technology)
    {
        var tech = new Technology
        {
            TechnologyId = technology.TechnologyId,
            TechnologyName = technology.TechnologyName,
            DirectionId = technology.DirectionId
        };

        _dbContextApp.Add(tech);
        await _dbContextApp.SaveChangesAsync();
    }

    public async Task<IEnumerable<Technology>> GetAllAsync()
    {
        var directions = await _dbContextApp.Technologies.Include(t => t.Employees)
                                                         .Include(t => t.Employees)
                                                         .Select(t => new Technology
                                                         {
                                                             TechnologyId = t.TechnologyId,
                                                             TechnologyName = t.TechnologyName,
                                                             Direction = t.Direction,
                                                             Employees = t.Employees
                                                         }).ToListAsync();
        return directions;
    }

    public async Task<Technology> GetByIdAsync(int id)
    {
        var directions = await _dbContextApp.Technologies.Include(t => t.Employees)
                                                         .Include(t => t.Employees)
                                                         .Select(t => new Technology
                                                         {
                                                             TechnologyId = t.TechnologyId,
                                                             TechnologyName = t.TechnologyName,
                                                             Direction = t.Direction,
                                                             Employees = t.Employees
                                                         })
                                                         .FirstOrDefaultAsync(t => t.TechnologyId == id);
        return directions;
    }

    public async Task UpdateAsync(Technology technology)
    {
        _dbContextApp.Update(technology);
        await _dbContextApp.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var technology = await _dbContextApp.Technologies.FindAsync(id);

        _dbContextApp.Technologies.Remove(technology);
        await _dbContextApp.SaveChangesAsync();
    }
}