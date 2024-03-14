using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        readonly private ETicaretAPIDbDontext _context;

        public WriteRepository(ETicaretAPIDbDontext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            // When a model of T type is added to database,
            // It returns ValueTask of EntityEntry
            // Through changetracking we can check the state of returned values state
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);

            return true;
        }

        public bool Remove(T model)
        {
            // Find the entity in the database
            EntityEntry<T> entityEntry = Table.Remove(model);
            // Check the entity's state via ChangeTracker to see if its deleted and return desired result (bool)
            return entityEntry.State != EntityState.Deleted;
        }
        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            Console.WriteLine("Delete function called");
            T model = await Table.FirstOrDefaultAsync(d => d.Id == Guid.Parse(id));
            Console.WriteLine(model);

            return Remove(model);

            
        }

        public bool Update(T model)
        {
            EntityEntry entityEntry =  Table.Update(model);

            return entityEntry.State == EntityState.Modified;

        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();


    }
}
 