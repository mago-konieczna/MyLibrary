using MyLibrary.Models;

namespace MyLibrary.Services.BookRepository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetBook(int id);
        Book PutBook(int id, Book book);
        void PostBook(Book book);
        void DeleteBook(int id);
        void Save();
        bool BookExists(int id);
    }
}
