using Microsoft.AspNetCore.Mvc;
using SWCodeReview.Models;
using SWCodeReview.Services;

namespace SWCodeReview.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
		private readonly IEmployeeService employeeService;

		public EmployeeController(IEmployeeService employeeService)
        {
			this.employeeService = employeeService;
		}

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = employeeService.GetAll().ToList();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            employee = await employeeService.AddAsync(employee);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = await employeeService.UpdateAsync(id, updatedEmployee);

            if (employee == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await employeeService.DeleteAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}