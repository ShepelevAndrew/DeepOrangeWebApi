using DeepOrangeWebApi.BLL.DTO;
using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.Entities;
using DeepOrangeWebApi.DAL.Repositories.Interfaces;

namespace DeepOrangeWebApi.BLL.Services.Implementations;
public class EmployeeService : IEmployeeService
{
    private readonly IBaseRepository<Employee> _employeeRepository;

	public EmployeeService(IBaseRepository<Employee> employeeRepository)
	{
		_employeeRepository = employeeRepository;
	}

	public async Task<IEnumerable<Employee>> GetEmployeesAsync()
	{
		var employees = await _employeeRepository.GetAllAsync();

		return employees;
	}
}
