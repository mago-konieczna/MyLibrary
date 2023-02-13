using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;
using MyLibrary.Services.Interfaces;

namespace MyLibrary.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }

        IEnumerable<Author> IAuthorRepository.GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthor(int id)
        {
            return _context.Authors.Find(id);
        }


        public Author PutAuthor(int id, Author author)
        {
            return _context.Authors.Find(id, author);
        }

        public void PostAuthor(Author author)
        {
            _context.Authors.Add(author);
        }

        public void DeleteAuthor(int id)
        {
            Author author = _context.Authors.Find(id);
            _context.Authors.Remove(author);
        }

        public bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }




    }

}
