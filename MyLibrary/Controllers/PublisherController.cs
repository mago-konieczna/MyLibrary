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
    public class PublisherController : ControllerBase
    {
        private IPublishersRepository _publishersRepository;

        public PublisherController(IPublishersRepository publishersRepository)
        {
            _publishersRepository = publishersRepository;
        }


        // GET: api/Publisher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publishers>>> GetPublishers()
        {
            return Ok(_publishersRepository.GetAll());
        }

        // GET: api/Publisher/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publishers>> GetPublishers(int id)
        {
            var publishers = _publishersRepository.GetPublishers(id);

            if (publishers == null)
            {
                return NotFound();
            }

            return Ok(publishers);
        }

        // PUT: api/Publisher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublishers(int id, Publishers publishers)
        {
            if (id != publishers.Id)
            {
                return BadRequest();
            }

            _publishersRepository.PutPublishers(id, publishers).Id = (int)EntityState.Modified;

            try
            {
                _publishersRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(id))
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

        // POST: api/Publisher
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publishers>> PostPublishers(Publishers publishers)
        {
            var newPublishers = new Publishers()
            { Id = publishers.Id,
            PublisherName = publishers.PublisherName,
            Books = new()
            }; 

            _publishersRepository.PostPublishers(newPublishers);
            _publishersRepository.Save();

            return CreatedAtAction(nameof(GetPublishers), new { id = publishers.Id }, publishers);
        }

        // DELETE: api/Publisher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublishers(int id)
        {
            var publishers = _publishersRepository.GetPublishers(id);
            if (publishers == null)
            {
                return NotFound();
            }

           _publishersRepository.DeletePublishers(id);
            _publishersRepository.Save();

            return NoContent();
        }

        private bool PublisherExists(int id)
        {
            return _publishersRepository.PublishersExists(id);
        }
    }
}
