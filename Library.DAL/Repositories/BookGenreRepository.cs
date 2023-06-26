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
    public class BookGenreRepository : IBookGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public BookGenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(BookGenre entity)
        {
            await _context.BookGenres.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(BookGenre entity)
        {
            _context.BookGenres.Remove(entity);
            return await Save();
        }

        public async Task<IEnumerable<BookGenre>> GetAllBookGenresAsync()
        {
            return await _context.BookGenres.ToListAsync();
        }

        public Task<BookGenre> GetBookGenreByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> Update(BookGenre entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await Save();
        }
    }
}
