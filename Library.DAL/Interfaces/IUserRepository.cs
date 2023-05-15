using Library.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserById(string id); 
        Task<IEnumerable<User>> GetAllUsers();
    }
}
