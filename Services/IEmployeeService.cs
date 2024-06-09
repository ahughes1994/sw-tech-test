using SWCodeReview.Models;

namespace SWCodeReview.Services
{
	public interface IEmployeeService
	{
		Employee Add(Employee employee);
		Employee? Delete(int id);
		IEnumerable<Employee> GetAll();
		Employee? GetById(int id);
		Employee? Update(int id, Employee employee);
	}
}