using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Get(Expression<Func<User, bool>> expression);
        Task<User> GetUserById(string id); 
        Task<IEnumerable<User>> Get();
        Task<IEnumerable<User>> GetManyUsers(Expression<Func<User, bool>> predicate);
    }
}
