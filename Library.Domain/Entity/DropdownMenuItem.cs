using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class DropdownMenuItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }
        public ICollection<SubMenuItem>? SubMenuItems { get; set; }
    }
}
