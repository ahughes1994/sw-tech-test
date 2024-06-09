using Microsoft.EntityFrameworkCore;
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

		public IEnumerable<Employee> GetAll(int skip = 0, int take = 10)
		{
			logger.LogInformation("Getting all employees.");

			return context.Employees.Skip(skip).Take(take).AsEnumerable();
		}

		public Employee? GetById(int id)
		{
			logger.LogInformation($"Getting employee with ID: {id}.");
			return context.Employees.FirstOrDefault(e => e.Id == id);
		}

		public async Task<Employee?> GetByIdAsync(int id)
		{
			logger.LogInformation($"Getting employee with ID: {id}.");
			return await context.Employees.FirstOrDefaultAsync(e => e.Id == id);
		}

		public Employee Add(Employee employee)
		{
			logger.LogInformation($"Adding employee.");

			context.Employees.Add(employee);
			context.SaveChanges();

			return employee;
		}

		public async Task<Employee> AddAsync(Employee employee)
		{
			logger.LogInformation($"Adding employee.");

			await context.Employees.AddAsync(employee);
			await context.SaveChangesAsync();

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

		public async Task<Employee?> UpdateAsync(int id, Employee employee)
		{
			logger.LogInformation($"Updating employee with ID: {id}.");

			var e = await context.Employees.FirstOrDefaultAsync(e => e.Id == id);

			if (e is null) return null;

			e.FirstName = employee.FirstName;
			e.LastName = employee.LastName;
			e.Age = employee.Age;
			e.Email = employee.Email;
			e.Salary = employee.Salary;

			await context.SaveChangesAsync();

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

		public async Task<Employee?> DeleteAsync(int id)
		{
			logger.LogInformation($"Deleting employee with ID: {id}.");

			var e = await context.Employees.FirstOrDefaultAsync(e => e.Id == id);

			if (e is null) return null;

			context.Employees.Remove(e);
			await context.SaveChangesAsync();

			return e;
		}
	}
}
