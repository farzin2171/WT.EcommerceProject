using System.Collections.Generic;
using System.Threading.Tasks;
using WT.Ecommerce.Database.Specifications;
using WT.Ecommerce.Domain.Models;

namespace WT.Ecommerce.Database.Repositories.Interfaces
{
	public interface IDatabaseRepository<T> :IRepository where T:BaseEntity
    {
		Task<T> GetByIdAsync(int id);
		Task<IReadOnlyList<T>> ListAllAsync();
		Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
		Task<T> AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task<int> CountAsync(ISpecification<T> spec);
		//Task BulkMergeAsync(IEnumerable<T> entities);
		//Task BulkDeleteAsync(IEnumerable<T> entities);
	}
}
