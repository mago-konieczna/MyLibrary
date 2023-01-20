using Microsoft.EntityFrameworkCore;


namespace MyLibrary.Models
{
    public class LibraryDbContext : DbContext   
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;";
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
       : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }  
       public DbSet<Author> Authors { get; set; }  
        public DbSet<Publishers> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }

    
}
