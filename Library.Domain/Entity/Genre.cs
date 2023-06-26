using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}
