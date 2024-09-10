using Carniceria.Entities;
using Microsoft.EntityFrameworkCore;

namespace Carniceria.Data
{
    public class CarniceriaContext : DbContext
    {
        

        public DbSet<Product> Products { get; set; }
        public DbSet<SaleForview> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Deborts> Deborts { get; set; }

        public CarniceriaContext(DbContextOptions<CarniceriaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User user1 = new User { id = 1, username = "admin", password = "admin" };

            modelBuilder.Entity<User>().HasData(user1);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.isDeleted);



            modelBuilder.Entity<SaleForview>()
            .HasOne(s => s.Product)
            .WithMany()
            .HasForeignKey(s => s.idProduct);

            base.OnModelCreating(modelBuilder);
        }

    }
}
