using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class SubMenuItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public int? DropdownMenuItemId { get; set; }
        public DropdownMenuItem? DropdownMenuItem { get; set; }
    }
}
