using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class Language
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedBy { get; set; }
        public bool isDelete { get; set; }
    }
}
