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
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            employee = employeeService.Add(employee);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = employeeService.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = employeeService.Update(id, updatedEmployee);

            if (employee == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employeeService.Delete(id);

            if (employee == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}