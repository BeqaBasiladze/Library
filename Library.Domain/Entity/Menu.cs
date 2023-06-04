using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string? MenuName { get; set; }
        public virtual ICollection<SubMenu> SubMenuItems { get; set;}

        public Menu()
        {
            SubMenuItems = new HashSet<SubMenu>();
        }
    }
}
