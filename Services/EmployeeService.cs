using SWCodeReview.DataAccess;
using SWCodeReview.Models;

namespace SWCodeReview.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly ILogger<EmployeeService> logger;
		private readonly IEmployeeRepository employeeRepository;

		public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository)
		{
			this.logger = logger;
			this.employeeRepository = employeeRepository;
		}

		public IEnumerable<Employee> GetAll(int skip = 0, int take = 10)
		{
			return employeeRepository.Get(skip, take);
		}

		public async Task<Employee?> GetById(int id)
		{
			return await employeeRepository.Read(id);
		}

		public async Task<Employee> Add(Employee employee)
		{
			return await employeeRepository.Create(employee);
		}

		public async Task<Employee?> Update(Employee employee)
		{
			return await employeeRepository.Update(employee);
		}

		public async Task<bool> Delete(int id)
		{
			return await employeeRepository.Delete(id);
		}
	}
}
