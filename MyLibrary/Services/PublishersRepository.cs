using MyLibrary.Controllers;
using MyLibrary.Models;
using MyLibrary.Services.Interfaces;

namespace MyLibrary.Services
{
    public class PublishersRepository : IPublishersRepository
    {
        private readonly LibraryDbContext _context;

        public PublishersRepository(LibraryDbContext context)
        {
            _context = context;
        }

        IEnumerable<Publisher> IPublishersRepository.GetAll()
        {
            return _context.Publishers.ToList();
        }

        public Publisher GetPublishers(int id)
        {
            return _context.Publishers.Find(id);
        }


        public Publisher PutPublishers(int id, Publisher publishers)
        {
            var existingPublishers = _context.Publishers.Find(id); if (existingPublishers is not null)
            {
                _context.Entry(publishers).CurrentValues.SetValues(publishers);
                return existingPublishers;
            }
            return default;
        }

        public void PostPublishers(Publisher publishers)
        {
            _context.Publishers.Add(publishers);
        }

        public void DeletePublishers(int id)
        {
            Publisher publishers = _context.Publishers.Find(id);
            _context.Publishers.Remove(publishers);
        }

        public bool PublishersExists(int id)
        {
            return _context.Publishers.Any(e => e.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
