using DeepOrangeWebApi.DAL.Entities;

namespace DeepOrangeWebApi.BLL.Services.Interfaces;
public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();
}