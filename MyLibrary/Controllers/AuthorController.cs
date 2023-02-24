using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;
using MyLibrary.Services.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository _authorRepository;
        private object _context;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }



        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return Ok(_authorRepository.GetAll());
            //return await _context.Authors.ToListAsync();
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = _authorRepository.GetAuthor(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
       
        public async Task<IActionResult> PutAuthor(int id, Author author)
         {

             if (id != author.Id)
             {
                 return BadRequest();
             }

             _authorRepository.PutAuthor(id, author).Id = (int)EntityState.Modified;

             try
             {
                 _authorRepository.Save();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!AuthorExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
         }

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            var newAuthor = new Author()
            {
                Id = author.Id,
                Name = author.Name,
                LastName = author.LastName,
                Country = author.Country,
                Books = new()
            };
            _authorRepository.PostAuthor(newAuthor);
            _authorRepository.Save();

            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = _authorRepository.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }

            _authorRepository.DeleteAuthor(id);
            _authorRepository.Save();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return _authorRepository.AuthorExists(id);
        }
    }
}
