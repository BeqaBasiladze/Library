using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class BookGenre
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDelete { get; set; }

    }
}
