using MyLibrary.Models;
using System.Security.Policy;

namespace MyLibrary.Services.Interfaces
{
    public interface IPublishersRepository
    {
        IEnumerable<Models.Publisher> GetAll();
        Models.Publisher GetPublishers(int id);
        Models.Publisher PutPublishers(int id, Models.Publisher publishers);
        void PostPublishers(Models.Publisher publishers);
        void DeletePublishers(int id);
        void Save();
        bool PublishersExists(int id);

    }
}
