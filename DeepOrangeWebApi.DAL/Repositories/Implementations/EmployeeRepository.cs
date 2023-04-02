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

    public async Task AddAsync(Employee employee)
    {
        var techList = new List<Technology>();

        var emp = new Employee
        {
            EmployeeId = employee.EmployeeId,
            Name = employee.Name,
            LastName = employee.LastName
        };

        foreach (var tech in employee.Technologies)
            techList.Add(await _dbContextApp.Technologies.FindAsync(tech.TechnologyId));

        emp.Technologies = techList;

        _dbContextApp.Employees.Add(emp);
        await _dbContextApp.SaveChangesAsync();
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

    public async Task<Employee> GetByIdAsync(int id)
    {
        var emp = await _dbContextApp.Employees.Include(e => e.Technologies)
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
                                               .SingleOrDefaultAsync(e => e.EmployeeId == id);

        return emp;
    }

    public async Task UpdateAsync(Employee employee)
    {
        var techList = new List<Technology>();

        var emp = await _dbContextApp.Employees.Include(e => e.Technologies)
                                               .ThenInclude(t => t.Direction)
                                               .SingleOrDefaultAsync(emp => emp.EmployeeId == employee.EmployeeId);

        foreach (var tech in employee.Technologies)
            techList.Add(await _dbContextApp.Technologies.FindAsync(tech.TechnologyId));

        emp.Technologies = techList;


        _dbContextApp.Employees.Update(emp);
        await _dbContextApp.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await _dbContextApp.Employees.FindAsync(id);

        _dbContextApp.Employees.Remove(employee);
        await _dbContextApp.SaveChangesAsync();
    }
}
