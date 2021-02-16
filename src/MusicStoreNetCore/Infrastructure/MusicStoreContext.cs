using Microsoft.EntityFrameworkCore;
using MusicStoreNetCore.Domain;

namespace MusicStoreNetCore.Infrastructure
{
    public class MusicStoreContext : DbContext
    {
        public MusicStoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Album>()
                .ToTable("Album")
                .Property(t => t.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Entity<Artist>().ToTable("Album");

            builder.Entity<Genre>().ToTable("Genre");

            builder.Entity<Order>()
               .ToTable("Order")
               .Property(t => t.Total)
               .HasColumnType("decimal(18,2)");

            builder.Entity<OrderDetail>()
               .ToTable("OrderDetail")
               .Property(t => t.UnitPrice)
               .HasColumnType("decimal(18,2)");

            builder.Entity<CartItem>().ToTable("CartItem");
        }
    }
}
