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
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Country entity)
        {
            await _context.Countries.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Country entity)
        {
            _context.Countries.Remove(entity);
            return await Save();
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> Update(Country entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
