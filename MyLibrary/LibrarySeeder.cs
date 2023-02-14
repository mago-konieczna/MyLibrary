using MyLibrary.Models;

namespace MyLibrary
{
    public class LibrarySeeder
    {
        private readonly LibraryDbContext _dbContext;

        public LibrarySeeder(LibraryDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Books.Any())
                {
                    var books = GetBook();
                    _dbContext.Books.AddRange(books);
                    _dbContext.SaveChanges();   
                }
            }
        }

        private IEnumerable<Book> GetBook()
        {
            var books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Hobbit",
                NumberISBN = 42701729,
                Pages = 320,
                PublicationDate = new DateTime(2014,11,07),
                Language = "polski",
                Category = "fantasy",
                Format = "książka",
                Description = "Wydanie klasycznego dzieła Tolkiena. Hobbit to istota większa od liliputa, mniejsza jednak od krasnala. Fantastyczny, przemyślany do najdrobniejszych szczegółów świat z powieści Tolkiena jest również jego osobistym tworem, a pod barwną fasadą nietrudno się dopatrzyć głębszego sensu i pewnych analogii do współczesności. ",
                ReadingStatus = true,
                Authors = new List<Author>
                {
                    new Author
                    {
                        Name = "John Ronald Reuel",
                        LastName = "Tolkien",
                        Country = "Wielka Brytania",

                    }
                },
                Publishers = new List<Publishers>
                {
                    new Publishers
                    {
                        PublisherName = "Wydawnictwo Iskry"
                    }

                }
            }
        };
            return books;   

    }
}
}
