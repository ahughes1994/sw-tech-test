using SWCodeReview.Models;

namespace SWCodeReview.DataAccess
{
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> Get(int skip, int take);
		Task<Employee> Create(Employee entity);
		IEnumerable<Employee> CreateMany(IEnumerable<Employee> entity);
		Task<bool> Delete(int id);
		void DeleteMany(IEnumerable<int> ids);
		Task<Employee?> Read(int id);
		IEnumerable<Employee> ReadMany(IEnumerable<int> ids);
		Task<Employee?> Update(Employee entity);
		IEnumerable<Employee> UpdateMany(IEnumerable<Employee> entities);
	}
}