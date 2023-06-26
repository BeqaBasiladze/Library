using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.Domain.ViewModel.Book
{
    public class AddBookViewModel
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public DateTime? PublicationDate { get; set; }
        [Required]
        public string? ISBN { get; set; }
        [Required]
        public int? Quantity { get; set; }

        [Required]
        public List<int>? GenreId { get; set; }
    }
}
