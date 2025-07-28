using System.Linq.Expressions;

namespace api.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity, int id);
        Task DeleteAsync(int id);

    }
}
