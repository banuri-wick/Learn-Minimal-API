using BookShopManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShopManagement.Infranstructure
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options)
        {}

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
                entity.Property(p => p.Id).IsRequired()
            );
        }
    }
}
