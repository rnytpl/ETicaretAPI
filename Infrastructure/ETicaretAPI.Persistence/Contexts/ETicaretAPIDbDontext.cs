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
                    // If given entities state meets the following conditions,
                    // apply the given functions
                    EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedTime = DateTime.UtcNow,
                    // If a deleted item's state is checked by CT
                    // It skips to last case specified in switch expression
                    // Thus attempts to treat it as if its been updated
                    // To eliminate this problem we've to return the 
                    _ => DateTime.UtcNow,
                };

            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Seed Data

            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();


            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    Price = 500,
                    Stock = 100,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 2",
                    Price = 600,
                    Stock = 200,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 3",
                    Price = 700,
                    Stock = 300,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 4",
                    Price = 800,
                    Stock = 400,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 5",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 6",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 7",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 8",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 9",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 10",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 11",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 12",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 13",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 14",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 15",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 16",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 17",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 18",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 19",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 5",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 5",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 5",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 5",
                    Price = 900,
                    Stock = 500,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                }


            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = id,
                    Name = "Faruk",
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Customer()
                {
                    Id = id2,
                    Name = "Aslan",
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    Id = Guid.NewGuid(),
                    Address = "Eraykent",
                    CustomerId = id,
                    Description = $"Customer {id}",
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Order()
                {
                    Id = Guid.NewGuid(),
                    Address = "Maltepe",
                    CustomerId = id,
                    Description = $"Customer {id}",
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                },
                new Order()
                {
                    Id = Guid.NewGuid(),
                    Address = "Kartal",
                    CustomerId = id2,
                    Description = $"Customer {id2}",
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow,
                }
            );

        }

    }
}
