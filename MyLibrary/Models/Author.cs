﻿namespace MyLibrary.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }

        public int BookId { get; set; } 
        public Book Book { get; set; }
        

    }
}
