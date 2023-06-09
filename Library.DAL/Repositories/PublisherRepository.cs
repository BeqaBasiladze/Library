﻿using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ApplicationDbContext _context;

        public PublisherRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Publisher>> GetAllPublishers()
        {
            return await _context.Publisher.ToListAsync();
        }

        public async Task<Publisher> GetPublisherById(int id)
        {
            return await _context.Publisher.FindAsync(id);
        }

        public async Task<bool> Create(Publisher entity)
        {
            await _context.Publisher.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Publisher entity)
        {
            _context.Publisher.Remove(entity);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> Update(Publisher entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
