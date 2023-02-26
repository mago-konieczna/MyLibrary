using MyLibrary.Models;
using MyLibrary.Services.Interfaces;

namespace MyLibrary.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        IEnumerable<Book> IBookRepository.GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return _context.Books.Find(id);
        }

        public Book PutBook(int id, Book book)
        {
            var existingBook = _context.Books.Find(id); if (existingBook is not null)
            {
                _context.Entry(book).CurrentValues.SetValues(book);
                return existingBook;
            }
            return default;
        }

        public void PostBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
        }

        public bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
