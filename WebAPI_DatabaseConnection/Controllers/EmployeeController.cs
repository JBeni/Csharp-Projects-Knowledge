using Microsoft.AspNetCore.Mvc;
using WebAPI_DatabaseConnection.IServices;
using WebAPI_DatabaseConnection.Models;

namespace WebAPI_DatabaseConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(_employeeService.GetEmployeeById(id));
        }

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeService.GetEmployees());
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            return Ok(_employeeService.AddEmployee(employee));
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            return Ok(_employeeService.UpdateEmployee(employee));
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            return Ok(_employeeService.DeleteEmployee(id));
        }
    }
}
