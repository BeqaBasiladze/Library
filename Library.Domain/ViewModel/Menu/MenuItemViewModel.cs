using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.ViewModel.Menu
{
    public class MenuItemViewModel
    {
        public string? Title { get; set; }
        public string? URL { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}
        public DateTime DeleteAt { get; set;}
        public bool IsDeleted { get; set; }
    }
}
