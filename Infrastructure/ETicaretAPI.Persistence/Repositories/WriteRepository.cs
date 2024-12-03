using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace ETicaretAPI.Persistence.Repositories
{
    // Expects a generic type of T to determine which entity this generic repository is going to operate on
    // Then passes the same entity type to IWriteRepository and ensures the generic type derives from a BaseEntity class
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        // Injects an instance of dbcontext into constructor to interact with database
        private readonly ETicaretAPIDbContext _context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        // Sets the entity type to work with

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            // Gives access to change tracking information and operations for the given entity
            EntityEntry result = await Table.AddAsync(model);
            // Ensures if the entity has been added
            return result.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            
            return true;

        }

        public bool Remove(T model)
        {
            // Gives access to change tracking information and operations for the given entity
            EntityEntry<T> entityEntry = Table.Remove(model);
            // Checks if the entity has been added and returns the result

            return entityEntry.State == EntityState.Deleted;
        }
        bool IWriteRepository<T>.RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);

            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T? model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));


            // Invokes the Remove method defined above
            return Remove(model);
        }

        public bool UpdateAsync(T model)
        {
            // Gives access to change tracking information and operations for the given entity
            EntityEntry entityEntry = Table.Update(model);
            // Checks if the entity has been added and returns the result
            return entityEntry.State == EntityState.Modified; 
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}
