using api.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Repository.Generic
{
    public class GenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FirstOrDefaultAsync(e => EF.Property<int>(e, "id") == id);
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e => EF.Property<int>(e, "id") == id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }



    }
}
