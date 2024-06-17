using Microsoft.EntityFrameworkCore;
using SWCodeReview.Models;

namespace SWCodeReview.DataAccess
{
	public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
	{
		private readonly ILogger<EmployeeRepository> logger;
		private readonly EmployeeContext context;

		public EmployeeRepository(ILogger<EmployeeRepository> logger, EmployeeContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public async override Task<Employee> Create(Employee entity)
		{
			logger.LogInformation($"Adding employee.");

			await context.Employees.AddAsync(entity);
			await context.SaveChangesAsync();

			return entity;
		}

		public override IEnumerable<Employee> CreateMany(IEnumerable<Employee> entity)
		{
			throw new NotImplementedException();
		}

		public async override Task<bool> Delete(int id)
		{
			logger.LogInformation($"Deleting employee with ID: {id}.");

			var e = await context.Employees.FirstOrDefaultAsync(e => e.Id == id);

			if (e is null) return false;

			context.Employees.Remove(e);
			await context.SaveChangesAsync();

			return true;
		}

		public override void DeleteMany(IEnumerable<int> ids)
		{
			throw new NotImplementedException();
		}

		public override IEnumerable<Employee> Get(int skip, int take)
		{
			logger.LogInformation("Getting employees.");
			return context.Employees.Skip(skip).Take(take).AsEnumerable();
		}

		public async override Task<Employee?> Read(int id)
		{
			logger.LogInformation($"Getting employee with ID: {id}.");
			return await context.Employees.FirstOrDefaultAsync(e => e.Id == id);
		}

		public override IEnumerable<Employee> ReadMany(IEnumerable<int> ids)
		{
			logger.LogInformation($"Getting employees with IDs: {string.Join(",", ids)}.");
			return context.Employees.Where(x => ids.Contains(x.Id));
		}

		public async override Task<Employee?> Update(Employee entity)
		{
			logger.LogInformation($"Updating employee with ID: {entity.Id}.");

			var e = await context.Employees.FirstOrDefaultAsync(e => e.Id == entity.Id);

			if (e is null) return null;

			e.FirstName = entity.FirstName;
			e.LastName = entity.LastName;
			e.Age = entity.Age;
			e.Email = entity.Email;
			e.Salary = entity.Salary;

			context.SaveChanges();

			return e;
		}

		public override IEnumerable<Employee> UpdateMany(IEnumerable<Employee> entities)
		{
			throw new NotImplementedException();
		}
	}
}
