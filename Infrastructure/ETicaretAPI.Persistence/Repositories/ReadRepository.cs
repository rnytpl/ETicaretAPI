using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETicaretAPI.Persistence.Repositories
{
    /// <summary>
    /// If tracking value is set to false
    /// Disable EF tracking mechanism
    /// This helps us optimize code to not perform tracking on entities on which we're not going to make any modifications
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        // Sets the table 
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true) {

            var query = Table.AsQueryable();
            // AsNoTracking() is a EF Core method that returns queries untracked by the context
            if (!tracking) query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true) {

            var query = Table.Where(method);

            if (!tracking) query = query.AsNoTracking(); 
            
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true) {

            var query = Table.AsQueryable();

            if (!tracking) query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);

        }
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking) query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

    }
}
