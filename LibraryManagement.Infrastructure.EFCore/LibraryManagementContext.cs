namespace LibraryManagement.Infrastructure.EFCore
{
    using LibraryManagement.Domain.Books;
    using Microsoft.EntityFrameworkCore;

    public class LibraryManagementContext : DbContext
    {
        public DbSet<Book> Books { get; set; }


        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id); // Configure primary key

            modelBuilder.Entity<Book>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd(); // Set Id as auto-generated
        }

    }

}
