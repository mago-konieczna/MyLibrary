﻿using Microsoft.EntityFrameworkCore;


namespace MyLibrary.Models
{
    public class LibraryDbContext : DbContext   
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
       : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }  
       public DbSet<Author> Authors { get; set; }  
        public DbSet<Publisher> Publishers { get; set; }  
    }
}
