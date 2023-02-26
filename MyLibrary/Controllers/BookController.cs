using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;
using MyLibrary.Services.Interfaces;

namespace MyLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

       
        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return Ok(_bookRepository.GetAll());
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book =  _bookRepository.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _bookRepository.PutBook(id, book).Id = (int)EntityState.Modified; 

            try
            {
                _bookRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            var newBook = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                NumberISBN = book.NumberISBN,
                Pages = book.Pages,
                PublicationDate = book.PublicationDate,
                Language = book.Language,
                Category = book.Category,
                Format = book.Format,
                Description = book.Description,
                ReadingStatus = book.ReadingStatus,
                Authors = book.Authors,
                Publishers = book.Publishers,   
            };
            _bookRepository.PostBook(newBook);
            _bookRepository.Save();

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = _bookRepository.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.DeleteBook(id);
            _bookRepository.Save();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _bookRepository.BookExists(id);
        }
    }
}
