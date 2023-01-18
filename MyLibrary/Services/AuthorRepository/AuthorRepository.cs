using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;

namespace MyLibrary.Services.AuthorRepository
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
    }

}
