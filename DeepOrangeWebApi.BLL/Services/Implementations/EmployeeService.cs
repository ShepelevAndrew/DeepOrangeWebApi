using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;

namespace DeepOrangeWebApi.BLL.Services.Implementations;
public class EmployeeService : IBaseService<Employee>
{
    private readonly IBaseRepository<Employee> _employeeRepository;

	public EmployeeService(IBaseRepository<Employee> employeeRepository)
	{
		_employeeRepository = employeeRepository;
	}

    public async Task CreateAsync(Employee employee)
    {
        await _employeeRepository.AddAsync(employee);
    }

    public async Task<IEnumerable<Employee>> GetAsync()
	{
		var employees = await _employeeRepository.GetAllAsync();

		return employees;
	}

    public async Task<Employee> GetByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        return employee;
    }

    public async Task UpdateAsync(Employee employee)
    {
        await _employeeRepository.UpdateAsync(employee);
    }

    public async Task DeleteAsync(int id)
    {
        await _employeeRepository.DeleteAsync(id);
    }
}
