using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _db.Users.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(User user)
        {
            _db.Users.Update(user);
            return Save();
        }
    }
}
