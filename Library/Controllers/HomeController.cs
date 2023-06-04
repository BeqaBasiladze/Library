using Library.DAL;
using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Library.Domain.ViewModel.Menu;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var menuItems = GetMenuItemsFromDatabase();
            return View(menuItems);
        }
        private List<MenuItemViewModel> GetMenuItemsFromDatabase()
        {
            return new List<MenuItemViewModel>
            {
                new MenuItemViewModel
                {
                    Title = "Home",
                    URL = "Home",
                    Description = "Home Page",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsDeleted = false
                },
                new MenuItemViewModel
                {
                    Title = "Registration",
                    URL = "Account/Register",
                    Description = "Registration Page",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsDeleted = false
                }
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}