using Library.Domain.Entity;
using Library.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
        }

        public void DeleteMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Remove(menuItem);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public MenuItem GetMenuItemById(int id)
        {
            return _context.MenuItems.Find(id);
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            _context.Entry(menuItem).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
