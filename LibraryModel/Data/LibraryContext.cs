using Microsoft.EntityFrameworkCore;
using Covaci_Adriana_Laborator2.Models;
using LibraryModel.Models;

namespace Covaci_Adriana_Laborator2.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Covaci_Adriana_Laborator2.Models.Order> Order { get; set; } = default;
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<PublishedBooks> PublishedBooks { get; set; } = default!;

        //public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurare relație 1-N între Author și Book
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorID);

       //     modelBuilder.Entity<City>()
       //.HasMany(c => c.Customer)
       //.WithOne(cu => cu.City)
       //.HasForeignKey(cu => cu.CityID)
       //.OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
