using Microsoft.EntityFrameworkCore;


namespace MyLibrary.Models
{
    public class LibraryDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;";
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
       : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "John Ronald Reuel",
                    LastName = "Tolkien",
                    Country = "Wielka Brytania",
                });
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    PublisherName = "Wydawnictwo Iskry"
                });
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Hobbit",
                    NumberISBN = 42701729,
                    Pages = 320,
                    PublicationDate = new DateTime(2014, 11, 07),
                    Language = "polski",
                    Category = "fantasy",
                    Format = "książka",
                    Description = "Wydanie klasycznego dzieła Tolkiena. Hobbit to istota większa od liliputa, mniejsza jednak od krasnala. Fantastyczny, przemyślany do najdrobniejszych szczegółów świat z powieści Tolkiena jest również jego osobistym tworem, a pod barwną fasadą nietrudno się dopatrzyć głębszego sensu i pewnych analogii do współczesności. ",
                    ReadingStatus = true,
                });
        }
    }
}
