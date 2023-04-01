using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeepOrangeWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet(Name = "GetEmployees")]
        public async Task<IEnumerable<Employee>> Get()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return employees;
        }    
    }
}