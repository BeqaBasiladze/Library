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
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Genre entity)
        {
            await _context.Genres.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Genre entity)
        {
            _context.Genres.Remove(entity);
            return await Save();
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetByGenreIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> Update(Genre entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
