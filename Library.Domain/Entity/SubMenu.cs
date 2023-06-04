using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entity
{
    public class SubMenu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string SubMenuName { get; set; }
        [StringLength(150)]
        public string TableName { get; set; }
        public bool HideFlag { get; set; }
        public int MenuId { get; set; }
        [ForeignKey(nameof(MenuId))]
        public virtual Menu MenuItems { get; set; }
    }
}
