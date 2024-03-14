using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    /// <summary>
    /// Entity type hiererchically passed from the class to the interface that the class inherits from and from there down to the IRepository that IReadRepository inherits from
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// To be able to connect to database, we've to create an instance of context class
        /// so that we can access to entities (tables) in database to perform operations
        /// </summary>
        private readonly ETicaretAPIDbDontext _context;

        public ReadRepository(ETicaretAPIDbDontext context)
        {
            _context = context;
        }

        // Sets the entity type so can we can access the corresponding table in the database

        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll(bool tracking = true)
        {

            var query = Table.OrderBy(t => t.CreatedTime).AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);

            if (!tracking) query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if(!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(method);
        }
        public async Task<T> GetById(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking) query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(q => q.Id == Guid.Parse(id));

        }

    }
}