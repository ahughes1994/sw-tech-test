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
        public IActionResult GetEmployees(int? skip, int? take)
        {
            var employees = employeeService.GetAll(skip ?? 0, take ?? 10).ToList();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            employee = await employeeService.Add(employee);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await employeeService.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee updatedEmployee)
        {
            var employee = await employeeService.Update(updatedEmployee);

            if (employee == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await employeeService.Delete(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}