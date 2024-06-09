using SWCodeReview.Models;

namespace SWCodeReview.Services
{
	public interface IEmployeeService
	{
		Employee Add(Employee employee);
		Task<Employee> AddAsync(Employee employee);
		Employee? Delete(int id);
		Task<Employee?> DeleteAsync(int id);
		IEnumerable<Employee> GetAll(int skip = 0, int take = 10);
		Employee? GetById(int id);
		Task<Employee?> GetByIdAsync(int id);
		Employee? Update(int id, Employee employee);
		Task<Employee?> UpdateAsync(int id, Employee employee);
	}
}