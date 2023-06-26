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
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext _context;
        public PositionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Position entity)
        {
            await _context.StaffPositions.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Position entity)
        {
            _context.StaffPositions.Remove(entity);
            return await Save();
        }

        public async Task<Position> GetPositionById(int id)
        {
            return await _context.StaffPositions.FindAsync(id);
        }

        public async Task<IEnumerable<Position>> GetAllPositions()
        {
            return await _context.StaffPositions.ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> Update(Position entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
