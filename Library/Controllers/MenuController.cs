using Library.DAL.Interfaces;
using Library.Domain.ViewModel.MenuView;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuNavigation _menuNavigation;

        public MenuController(IMenuNavigation menuNavigation)
        {
            _menuNavigation = menuNavigation;
        }
        public IActionResult Index()
        {
            MenuViewModel viewModel = new MenuViewModel();
            viewModel.MenuList = _menuNavigation.GetMenuList().Result.ToList();
            return View(viewModel);
        }
    }
}
