using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        
        public virtual void Delete(Expression<Func<User, bool>> predicate)
        {
            IEnumerable<User> obj = _db.Users.Where(predicate).AsEnumerable();
            foreach (User item in obj)
            {
                _db.Users.Remove(item);
            }
        }

        public User Get(Expression<Func<User, bool>> predicate)
        {
            IEnumerable<User> obj = _db.Users.Where(predicate);
            return (User)obj;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetManyUsers(Expression<Func<User, bool>> predicate)
        {
            return await _db.Users.Where(predicate).ToListAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            //var user = await _db.Users.FindAsync(id);
            var user = await _db.Users.Where(c=>c.Id ==  id).FirstOrDefaultAsync();
            return user;
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(User user)
        {
            _db.Users.Update(user);
            user.ModifiedAt = DateTime.Now;
            return Save();
        }
    }
}
