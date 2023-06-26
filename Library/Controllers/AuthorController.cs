using Library.DAL.Interfaces;
using Library.DAL.Repositories;
using Library.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _authorRepository.GetAllAuthors();
            return View(authors);
        }

        public async Task<IActionResult> Details(int id)
        {
            var author = await _authorRepository.GetAuthorById(id);
            if(author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorRepository.Create(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var authors = await _authorRepository.GetAuthorById(id);
            if (authors == null)
            {
                return NotFound();
            }
            return View(authors);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorRepository.Update(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var authors = await _authorRepository.GetAuthorById(id);
            if (authors == null)
            {
                return NotFound();
            }
            return View(authors);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Author author)
        {
            await _authorRepository.Delete(author);
            return RedirectToAction("Index");
        }
    }
}
