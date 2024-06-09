using SWCodeReview.DataAccess;
using SWCodeReview.Models;

namespace SWCodeReview.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly ILogger<EmployeeService> logger;
		private readonly EmployeeContext context;

		public EmployeeService(ILogger<EmployeeService> logger, EmployeeContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public IEnumerable<Employee> GetAll()
		{
			logger.LogInformation("Getting all employees.");
			return context.Employees.AsEnumerable();
		}

		public Employee? GetById(int id)
		{
			logger.LogInformation($"Getting employee with ID: {id}.");
			return context.Employees.FirstOrDefault(e => e.Id == id);
		}

		public Employee Add(Employee employee)
		{
			logger.LogInformation($"Adding employee.");

			context.Employees.Add(employee);
			context.SaveChanges();

			return employee;
		}

		public Employee? Update(int id, Employee employee)
		{
			logger.LogInformation($"Updating employee with ID: {id}.");

			var e = context.Employees.FirstOrDefault(e => e.Id == id);

			if (e is null) return null;

			e.FirstName = employee.FirstName;
			e.LastName = employee.LastName;
			e.Age = employee.Age;
			e.Email = employee.Email;
			e.Salary = employee.Salary;

			context.SaveChanges();

			return e;
		}

		public Employee? Delete(int id)
		{
			logger.LogInformation($"Deleting employee with ID: {id}.");

			var e = context.Employees.FirstOrDefault(e => e.Id == id);

			if (e is null) return null;

			context.Employees.Remove(e);
			context.SaveChanges();

			return e;
		}
	}
}
