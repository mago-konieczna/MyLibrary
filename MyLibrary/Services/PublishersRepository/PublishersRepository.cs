using MyLibrary.Controllers;
using MyLibrary.Models;

namespace MyLibrary.Services.PublishersRepository
{
    public class PublishersRepository : IPublishersRepository 
    {
        private readonly LibraryDbContext _context;

        public PublishersRepository(LibraryDbContext context)
        {
            _context = context;
        }

        IEnumerable<Publishers> IPublishersRepository.GetAll()
        {
            return _context.Publishers.ToList();
        }

        public Publishers GetPublishers(int id)
        {
            return _context.Publishers.Find(id);
        }


        public Publishers PutPublishers(int id, Publishers publishers)
        {
            return _context.Publishers.Find(id, publishers);
        }

        public void PostPublishers(Publishers publishers)
        {
            _context.Publishers.Add(publishers);
        }

        public void DeletePublishers(int id)
        {
            Publishers publishers = _context.Publishers.Find(id);
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
