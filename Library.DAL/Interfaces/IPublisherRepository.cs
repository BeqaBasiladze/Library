using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IPublisherRepository
    {
        Publisher GetPublisherById(int id);
        IEnumerable<Publisher> GetAllPublishers();
        void AddPublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(Publisher publisher);
    }
}
