using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set;}
        public bool isDelete { get; set; }
        public List<Publisher> publisherList { get; set; } = new();

        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
