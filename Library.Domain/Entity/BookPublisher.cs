using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class BookPublisher
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public List<Book>? Books { get; set;}
        public int PublisherId { get; set; }
        public List<Publisher>? Publishers { get; set;}
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}
