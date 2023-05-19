using Library.DAL.Interfaces;
using Library.Domain.Helpers;
using Library.Domain.ViewModel.User;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> UserDelete(string id)
        {
            var user = _userRepository.Get(x => x.Id == id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                IsDelete = true
            };
            return View(userDetailViewModel);
        }

        [HttpGet("Users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.Get();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                result.Add(userViewModel);
            }
            return View(result);
        }

        public async Task<IActionResult> GetPaggedData(int pageNumber = 1, int pageSize = 20)
        {
            var users = await _userRepository.Get();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                result.Add(userViewModel);
            }
            var pagedData = Pagination.PagedResult(result, pageNumber, pageSize);
            return Json(pagedData);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.PasswordHash,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return View(userDetailViewModel);
        }
    }
}
