using DeepOrangeWebApi.DAL.EF;
using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeepOrangeWebApi.DAL.Repositories.Implementations;

public class EmployeeRepository : IBaseRepository<Employee>
{
    private readonly DbContextApp _dbContextApp;

	public EmployeeRepository(DbContextApp dbContextApp)
	{
        _dbContextApp = dbContextApp;
	}

    public void Add(Employee customer)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        var employees = await _dbContextApp.Employees
                                            .Include(e => e.Technologies)
                                                .ThenInclude(t => t.Direction)
                                            .Select(e => new Employee
                                            {
                                                EmployeeId = e.EmployeeId,
                                                Name = e.Name,
                                                LastName = e.LastName,
                                                Technologies = e.Technologies.Select(t => new Technology
                                                {
                                                    TechnologyId = t.TechnologyId,
                                                    TechnologyName = t.TechnologyName,
                                                    DirectionId = t.DirectionId,
                                                    Direction = new Direction
                                                    {
                                                        DirectionId = t.Direction.DirectionId,
                                                        DirectionName = t.Direction.DirectionName
                                                    }
                                                }).ToList()
                                            })
                                            .ToListAsync();

        return employees;
    }

    public Employee GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Employee customer)
    {
        throw new NotImplementedException();
    }
}
