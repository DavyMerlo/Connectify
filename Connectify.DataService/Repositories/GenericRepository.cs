using Connectify.DataService.Data;
using Connectify.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Connectify.DataService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ILogger _logger;
        protected AppDbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(
                AppDbContext context,
                ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T?> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
