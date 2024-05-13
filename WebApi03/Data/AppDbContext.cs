using Microsoft.EntityFrameworkCore;
using WebApi03.Models;

namespace WebApi03.Data
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<Books> Books { get; set; }
            public DbSet<Authors> Authors { get; set; }
            public DbSet<Publishers> Publishers { get; set; }
            public DbSet<Models.BookAuthor> BookAuthor { get; set; }


            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.Entity<Models.BookAuthor>().HasKey(h => new { h.BooksID, h.AuthorsID });

                builder.Entity<Models.BookAuthor>().HasOne(h => h.Books).WithMany(h => h.Book_Authors).HasForeignKey(h => h.BooksID);

                builder.Entity<Models.BookAuthor>().HasOne(h => h.Author).WithMany(h => h.Book_Authors).HasForeignKey(h => h.AuthorsID);

                new SQL(builder).Seed();
            }
        }
    }

