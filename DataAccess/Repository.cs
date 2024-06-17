namespace SWCodeReview.DataAccess
{
	public abstract class Repository<T> where T : class
	{
		public abstract IEnumerable<T> Get(int skip, int take);

		public abstract Task<T> Create(T entity);

		public abstract IEnumerable<T> CreateMany(IEnumerable<T> entity);

		public abstract Task<T?> Read(int id);

		public abstract IEnumerable<T> ReadMany(IEnumerable<int> ids);

		public abstract Task<T?> Update(T entity);

		public abstract IEnumerable<T> UpdateMany(IEnumerable<T> entities);

		public abstract Task<bool> Delete(int id);

		public abstract void DeleteMany(IEnumerable<int> ids);
	}
}
