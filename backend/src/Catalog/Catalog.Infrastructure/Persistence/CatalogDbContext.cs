using Catalog.Catalog.Infrastructure.Books;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Catalog.Infrastructure.Persistence;

public class CatalogDbContext : DbContext
{
    public DbSet<BookEntity> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BookEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Author).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.BookStatus).IsRequired().HasConversion<int>();
            }
        );
    }
}