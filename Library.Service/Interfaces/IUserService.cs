using Library.Domain.Entity;
using Library.Domain.Response;
using Library.Domain.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Interfaces
{
    public interface IUserService
    {
        IBaseResponse<IEnumerable<User>> GetAllUsers();
        public IBaseResponse<User> GetUserById(int id);
        public IBaseResponse<User> GetUserByName(string name);
        public IBaseResponse<bool> DeleteUser(int id);
        public IBaseResponse<UserViewModel> CreateUser(UserViewModel userViewModel);
        public IBaseResponse<User> EditeUser(int id, UserViewModel model);
    }
}