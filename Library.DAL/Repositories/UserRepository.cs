using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Microsoft.EntityFrameworkCore;

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
            _db.Users.Add(entity);
            _db.SaveChanges();

            return true;
        }

        public bool Delete(User entity)
        {
            _db.Users.Remove(entity);
            _db.SaveChanges();

            return true;
        }

        //public User Get(int id)
        //{
        //    return _db.Users.FirstOrDefault(x => x.ID == id);
        //}

        //public User GetByName(string name)
        //{
        //    return _db.Users.FirstOrDefault(x => x.UserName == name);
        //}

        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }

        public User Update(User entity)
        {
            _db.Users.Update(entity);
            _db.SaveChanges();
            return entity;
        }
    }
}
