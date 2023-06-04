using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Library.Domain.Helpers;
using Library.Domain.ViewModel.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index(int currentPage = 1)
        {
            var users = await _userRepository.Get();
            List<UserViewModel> result = new List<UserViewModel>();
            var userViewModel = new UserViewModel();


            int totalRecords = users.Count();
            int pageSize = 5;
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
            users = users.Skip((currentPage - 1) * pageSize).Take(pageSize);

            foreach (var user in users)
            {
                userViewModel.Id = user.Id;
                userViewModel.UserName = user.UserName;
                result.Add(userViewModel);
            }
            userViewModel.CurrentPage = currentPage;
            userViewModel.TotalPages = totalPages;
            userViewModel.PageSize = pageSize;
            return View(result);
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
