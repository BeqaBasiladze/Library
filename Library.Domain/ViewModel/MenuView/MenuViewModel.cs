using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.ViewModel.MenuView
{
    public class MenuViewModel
    {
        public IEnumerable<Menu> MenuList { get; set; }
    }
}
