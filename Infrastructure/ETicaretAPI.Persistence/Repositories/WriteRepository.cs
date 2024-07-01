using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        private readonly ETicaretAPIDbContext _context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        // Passes entity type to _context class



        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry result = await Table.AddAsync(model);

            return result.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            
            return true;

        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        bool IWriteRepository<T>.RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);

            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));


            // Invokes the Remove method defined above
            return Remove(model);
        }

        public bool UpdateAsync(T model)
        {
            EntityEntry entityEntry = Table.Update(model);

            return entityEntry.State == EntityState.Modified; 
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}
