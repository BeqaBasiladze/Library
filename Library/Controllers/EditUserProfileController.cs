using Library.DAL.Interfaces;
using Library.Domain.ViewModel.User;
using Library.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class EditUserProfileController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;

        public EditUserProfileController(IHttpContextAccessor contextAccessor,IUserRepository userRepository)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }

        private void MapUserEdit(User user, EditUserProfileViewModel viewModel)
        {
            user.Id = viewModel.Id;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Email = viewModel.Email;
            user.UserName = viewModel.UserName;
        }
        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetUserById(curUserId);
            if(user == null)
            {
                return View("Error");
            }
            var editUserViewModel = new EditUserProfileViewModel()
            {
                Id = curUserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserProfileViewModel modelEdit)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Faild to edit profile");
                return View("EditUserProfile", modelEdit);
            }

            var user = await _userRepository.GetUserById(modelEdit.Id);
            if(user.Id != "" || user.Id != null)
            {
                MapUserEdit(user, modelEdit);

                _userRepository.Update(user);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
