using Library.DAL.Interfaces;
using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ApplicationDbContext _context;

        public PublisherRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public void DeletePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            throw new NotImplementedException();
        }

        public Publisher GetPublisherById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }
    }
}
