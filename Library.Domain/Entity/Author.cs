using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirtDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set;}
        public DateTime ModifiedAt { get; set;}
        public DateTime CreateAt { get; set;}

        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
