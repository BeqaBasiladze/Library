using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Library.Domain.Enum;
using Library.Domain.Response;
using Library.Domain.ViewModel.User;
using Library.Service.Interfaces;

namespace Library.Service.Implementations
{
    public class UserService /*: IUserService*/
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public IBaseResponse<User> GetUserById(int id)
        //{
        //    var baseResponse = new BaseResponse<User>();
        //    try
        //    {
        //        var user = _userRepository.GetAll().FirstOrDefault(x => x.ID == id);
        //        if (user == null)
        //        {
        //            baseResponse.Description = "User not found";
        //            baseResponse.StatusCode = StatusCode.UserNotFound;
        //            return baseResponse;
        //        }
        //        baseResponse.Data = user;
        //        baseResponse.StatusCode = StatusCode.OK;
        //        return baseResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResponse<User>()
        //        {
        //            Description = $"[GetUser] : {ex.Message}",
        //            StatusCode = StatusCode.InternalServerError
        //        };
        //    }
        //}

        //public IBaseResponse<User> GetUserByName(string name)
        //{
        //    var baseResponse = new BaseResponse<User>();
        //    try
        //    {
        //        var user = _userRepository.GetAll().FirstOrDefault(x => x.UserName == name);
        //        if (user == null)
        //        {
        //            baseResponse.Description = "User not found";
        //            baseResponse.StatusCode = StatusCode.UserNotFound;
        //            return baseResponse;
        //        }
        //        baseResponse.Data = user;
        //        baseResponse.StatusCode = StatusCode.OK;
        //        return baseResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResponse<User>()
        //        {
        //            Description = $"[GetUserByName] : {ex.Message}",
        //            StatusCode = StatusCode.InternalServerError
        //        };
        //    }
        //}

        //public IBaseResponse<IEnumerable<User>> GetAllUsers()
        //{
        //    var baseResponse = new BaseResponse<IEnumerable<User>>();
        //    try
        //    {
        //        var users = _userRepository.GetAll();
        //        if (users.Count() == 0)
        //        {
        //            baseResponse.Description = "Zero elements found.";
        //            baseResponse.StatusCode = StatusCode.UserNotFound;
        //            return baseResponse;
        //        }

        //        baseResponse.Data = users;
        //        baseResponse.StatusCode = StatusCode.OK;
        //        return baseResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResponse<IEnumerable<User>>()
        //        {
        //            Description = $"[GetAllUsers] : {ex.Message}",
        //            StatusCode = StatusCode.InternalServerError
        //        };
        //    }
        //}

        //public IBaseResponse<bool> DeleteUser(int id)
        //{
        //    var baseResponse = new BaseResponse<bool>();
        //    try
        //    {
        //        var user = _userRepository.GetAll().FirstOrDefault(x => x.ID == id);
        //        if (user == null)
        //        {
        //            baseResponse.Description = "User not found.";
        //            baseResponse.StatusCode = StatusCode.UserNotFound;
        //            return baseResponse;
        //        }
        //        _userRepository.Delete(user);
        //        baseResponse.StatusCode = StatusCode.OK;
        //        return baseResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResponse<bool>()
        //        {
        //            Description = $"[DeleteUser] : {ex.Message}",
        //            StatusCode = StatusCode.InternalServerError
        //        };
        //    }
        //}

        //public IBaseResponse<UserViewModel> CreateUser(UserViewModel userViewModel)
        //{
        //    var baseResponse = new BaseResponse<UserViewModel>();
        //    try
        //    {
        //        var user = new User()
        //        {
        //            UserName = userViewModel.UserName,
        //            Email = userViewModel.Email,
        //            Password = userViewModel.Password
        //        };
        //        _userRepository.Create(user);
        //        baseResponse.StatusCode = StatusCode.OK;
        //        return baseResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResponse<UserViewModel>()
        //        {
        //            Description = $"[CreateUser] : {ex.Message}",
        //            StatusCode = StatusCode.InternalServerError
        //        };
        //    }
        //}

        //public IBaseResponse<User> EditeUser(int id, UserViewModel model)
        //{
        //    var baseResponse = new BaseResponse<User>();
        //    try
        //    {
        //        var user = _userRepository.GetAll().FirstOrDefault(x => x.ID == id);
        //        if (user == null)
        //        {
        //            baseResponse.Description = "User not found";
        //            baseResponse.StatusCode = StatusCode.UserNotFound;
        //            return baseResponse;
        //        }
        //        user.UserName = model.UserName;
        //        user.Email = model.Email;
        //        user.Password = model.Password;
        //        _userRepository.Update(user);
        //        baseResponse.StatusCode = StatusCode.OK;
        //        return baseResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResponse<User>()
        //        {
        //            Description = $"[EditeUser] : {ex.Message}",
        //            StatusCode = StatusCode.InternalServerError
        //        };
        //    }
        //}
    }
}
