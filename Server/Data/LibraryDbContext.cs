using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasKey(book => book.Id);
            modelBuilder.Entity<Author>()
                .HasKey(author => author.Id);
            modelBuilder.Entity<Book>()
                .HasMany(book => book.Authors)
                .WithMany(author => author.Books);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}