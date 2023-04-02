using DeepOrangeWebApi.BLL.Services.Interfaces;
using DeepOrangeWebApi.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeepOrangeWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IBaseService<Employee> _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IBaseService<Employee> employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            await _employeeService.CreateAsync(employee);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            var employees = await _employeeService.GetAsync();
            return employees;
        }

        [HttpGet]
        public async Task<Employee> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            return employee;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employee)
        {
            await _employeeService.UpdateAsync(employee);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return Ok();
        }
    }
}