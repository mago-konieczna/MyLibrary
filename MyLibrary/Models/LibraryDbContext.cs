using Microsoft.EntityFrameworkCore;


namespace MyLibrary.Models
{
    public class LibraryDbContext : DbContext   
    {
        public DbSet<Book> Books { get; set; }  
        public DbSet<Author> Authors { get; set; }  
        public DbSet<Publisher> Publishers { get; set; }  
    }
}
