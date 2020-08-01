namespace Persistence
{
    using Domain.Auth;
    using Domain.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Deliverer> Deliverers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Role>(x => x.HasKey(r => r.RoleId));
            builder.Entity<Customer>(x => x.HasKey(c => c.CustomerId));
            builder.Entity<Deliverer>(x => x.HasKey(d => d.DelivererId ));
            builder.Entity<Product>(x => x.HasKey(p=> p.ProductId));
            builder.Entity<Category>(x => x.HasKey(c => c.CategoryId));
            builder.Entity<Order>(x => x.HasKey(o => o.OrderId));
            builder.Entity<OrderDetail>(x => x.HasKey(o => o.OrderDetailId));
            builder.Entity<Payment>(x => x.HasKey(p => p.PaymentId));
            builder.Entity<OrderDetail>(x => x.HasKey(o => o.OrderDetailId));
            builder.Entity<Delivery>(x => x.HasKey(d => d.DeliveryId));

            builder.Entity<Role>()
                .HasMany(u => u.Users)
                .WithOne(r => r.UserRole);

            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(c => c.ProductCategory);

            builder.Entity<Order>()
                .HasMany(o => o.Payments)
                .WithOne(p => p.Order);

            builder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(p => p.Order);

            builder.Entity<Order>()
                .HasMany(o => o.Deliveries)
                .WithOne(p => p.Order);
            
            builder.Entity<Order>()
                .HasMany(o => o.Payments)
                .WithOne(p => p.Order);

            builder.Entity<Product>()
                .HasMany(o => o.OrderDetails)
                .WithOne(p => p.Product);

            builder.Entity<Deliverer>()
                .HasMany(o => o.Deliveries)
                .WithOne(p => p.Deliverer);
        }
    }
}
