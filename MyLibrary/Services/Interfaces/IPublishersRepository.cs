using MyLibrary.Models;
using System.Security.Policy;

namespace MyLibrary.Services.Interfaces
{
    public interface IPublishersRepository
    {
        IEnumerable<Publishers> GetAll();
        Publishers GetPublishers(int id);
        Publishers PutPublishers(int id, Publishers publishers);
        void PostPublishers(Publishers publishers);
        void DeletePublishers(int id);
        void Save();
        bool PublishersExists(int id);

    }
}
