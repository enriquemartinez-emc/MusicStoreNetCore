using Microsoft.EntityFrameworkCore;
using MusicStoreNetCore.Domain;
using System.Reflection;

namespace MusicStoreNetCore.Infrastructure
{
    public class MusicStoreContext : DbContext
    {
        public MusicStoreContext(DbContextOptions options) : base(options)
        {
        }

        public  DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
