using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStoreNetCore.Domain;

namespace MusicStoreNetCore.Infrastructure.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.Property(t => t.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
