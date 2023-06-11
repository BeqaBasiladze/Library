using Library.DAL;
using Library.DAL.Repositories;
using Library.Domain.Entity;
using Library.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemRepository _repository;
        public MenuItemController(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var menuItem = _repository.GetAllMenuItems();
            return View(menuItem);
        }
        public IActionResult Details(int id)
        {
            var menuItem =_repository.GetMenuItemById(id);
            if(menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MenuItem menuItem)
        {
            if(ModelState.IsValid)
            {
                _repository.AddMenuItem(menuItem);
                return RedirectToAction("Index");
            }
            return View(menuItem);
        }
        public IActionResult Edit(int id)
        {
            var menuItem = _repository.GetMenuItemById(id);
            if(menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MenuItem menuItem)
        {
            if(ModelState.IsValid)
            {
                _repository.UpdateMenuItem(menuItem);
                return RedirectToAction("index");
            }
            menuItem.ModifiedAt = DateTime.Now;
            return View(menuItem);
        }
        public IActionResult Delete(int id)
        {
            var menuItem = _repository.GetMenuItemById(id);
            if( menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(MenuItem menuItem)
        {
            _repository.DeleteMenuItem(menuItem);
            return RedirectToAction("Index");
        }
    }
}
