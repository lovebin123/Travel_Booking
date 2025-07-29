using System.Linq.Expressions;

namespace api.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetQueryable(); 
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> SaveChangesAsync();
    }
}
