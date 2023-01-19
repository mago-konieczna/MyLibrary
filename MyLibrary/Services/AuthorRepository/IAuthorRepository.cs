using Microsoft.AspNetCore.Mvc;
using MyLibrary.Models;

namespace MyLibrary.Services.AuthorRepository
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Author GetAuthor(int id);
        Author PutAuthor(int id, Author author);
        void PostAuthor(Author author);
        void DeleteAuthor(int id);  
        void Save();
        bool AuthorExists(int id);
    }
}
