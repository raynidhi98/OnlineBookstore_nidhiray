using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data.Models;

namespace OnlineBookstore.Data
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; } // Add your DbSets
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-V7K30T9\\SQLEXPRESS;Database=OnlineBookstoreDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasPrecision(18, 4);  // Adjust scale as per your need

            base.OnModelCreating(modelBuilder);
        }

    }
}
