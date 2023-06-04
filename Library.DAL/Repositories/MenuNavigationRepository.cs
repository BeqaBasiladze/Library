using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class MenuNavigationRepository : IMenuNavigation
    {
        private readonly ApplicationDbContext _context;

        public MenuNavigationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> GetMenuList()
        {
            return await _context.Menus.Include(m => m.SubMenuItems).ToListAsync();
        }

        public async Task<IEnumerable<SubMenu>> GetSubMenuList()
        {
            return await _context.SubMenus.Include(m=>m.MenuItems).ToListAsync();
        }
    }
}
