using SWCodeReview.Models;

namespace SWCodeReview.Services
{
	public interface IEmployeeService
	{
		Task<Employee> Add(Employee employee);
		Task<bool> Delete(int id);
		IEnumerable<Employee> GetAll(int skip = 0, int take = 10);
		Task<Employee?> GetById(int id);
		Task<Employee?> Update(Employee employee);
	}
}