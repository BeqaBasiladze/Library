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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Author entity)
        {
            await _context.Authors.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Author entity)
        {
            _context.Authors.Remove(entity);
            return await Save();
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false; ;
        }

        public async Task<bool> Update(Author entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
