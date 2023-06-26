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
    public class LanguageRepository : ILanguagesRepository
    {
        private readonly ApplicationDbContext _context;
        public LanguageRepository(ApplicationDbContext context)
        {
                _context = context;
        }
        public async Task<bool> Create(Language entity)
        {
            await _context.Languages.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Language entity)
        {
            _context.Languages.Remove(entity);
            return await Save();
        }

        public async Task<IEnumerable<Language>> GetAllLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<Language> GetLangeageById(int id)
        {
            return await _context.Languages.FindAsync(id);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> Update(Language entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
