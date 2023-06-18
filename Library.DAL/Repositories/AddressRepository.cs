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
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Address entity)
        {
            await _context.Addresses.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Address entity)
        {
            _context.Addresses.Remove(entity);
            return await Save();
        }

        public async Task<Address> GetAddressById(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false; ;
        }

        public async Task<bool> Update(Address entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await Save();
        }
    }
}
