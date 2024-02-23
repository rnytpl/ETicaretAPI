using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbDontext : DbContext
    {
        public ETicaretAPIDbDontext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// SaveChangesAsync method in WriteRepository takes a parameter of cancellationToken parameter of CancellationToken type
        /// Depending on which parameter SaveChangesAsync method takes, we've to override the appropriate overload of SaveChangesAsync method from DbContext
        /// </summary>
        /// To eliminate the need of specifying the type of each entity

        /// Since every entity that is derived and will derive from BaseEntity class, it is costful and useless to pass each entity type to Entries method of ChangeTracker
        /// it'll be more appropriate to pass a more generic type,Base entity 
        /// <param name="cancellationToken"></param>
        /// <returns></returns>



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            var datas = ChangeTracker.Entries<BaseEntity>();
            
            foreach (var data in datas)
            {
                _ = data.State switch
                {

                    EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedTime = DateTime.UtcNow,
                };

            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
