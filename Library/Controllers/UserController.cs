using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Library.Domain.ViewModel.User;
using Library.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers() // get all users
        {
            var response = _userService.GetAllUsers();
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public IActionResult GetUser(int id) // get user by id
        {
            var response = _userService.GetUserById(id);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var response = _userService.DeleteUser(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetUsers");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Save(int id)
        {
            if(id == 0)
            {
                return View();
            }

            var response = _userService.GetUserById(id);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        //[HttpPost]
        //public IActionResult Save(UserViewModel model)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        if(model.ID == 0)
        //        {
        //            _userService.CreateUser(model);
        //        }
        //        else
        //        {
        //            _userService.EditeUser(model.ID, model);
        //        }
        //    }
        //    return RedirectToAction("GetUsers");
        //}

        public IActionResult CreateUser()
        {
            return View();
        }
    }
}
