using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Models
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext (DbContextOptions<LibraryDBContext> options) : base (options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<CartLine>();
        }
    }
}
