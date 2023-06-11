using Library.DAL;
using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Library.Models;
using Library.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuItemRepository _menuItemRepository;

        public HomeController(ILogger<HomeController> logger, IMenuItemRepository menuItemRepository)
        {
            _logger = logger;
            _menuItemRepository = menuItemRepository;
        }
        public IActionResult Index()
        {
            var menuItems = _menuItemRepository.GetAllMenuItems();
            return View(menuItems);
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