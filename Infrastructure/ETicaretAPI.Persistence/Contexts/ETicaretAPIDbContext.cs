using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //var products = new Product[300];

            //for (int i = 0; i < 300; i++)
            //{
            //    products[i] = new Product
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = $"Product {i + 1}",
            //        Description = "A brief description of the product, highlighting its key features and benefits.",
            //        Price = i + 1,
            //        Stock = i + 1,
            //        CreatedDate = DateTime.UtcNow,
            //    };
            //}

            //builder.Entity<Product>()
            //    .HasData(products);

            // Sets the id of Order as primary key
            builder.Entity<Order>()
                .HasKey(o => o.Id);

            // A basket has one Order
            // An order has one Basket
            // Configures OrderId as foreign key
            builder.Entity<Basket>()
                .HasOne(o => o.Order)
                .WithOne(b => b.Basket)
                .HasForeignKey<Order>(b => b.Id);

            base.OnModelCreating(builder);
        }

        /// <summary>
        /// Overriding SaveChangesAsync method enables to intervene and apply modifications before changes are saved to database
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Detects modifications made on entities every time SaveChangesAsync method is invoked
            // Returns entities of a given type that are being tracked
            var datas = ChangeTracker.Entries<BaseEntity>();
            // Iterates each entry returned from changetracker
            // Checks entity's state if it meets a certain condition and assigns a value to it
            foreach (var data in datas) {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        

    }
}
