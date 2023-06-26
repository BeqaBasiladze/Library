using Library.DAL.Interfaces;
using Library.DAL.Repositories;
using Library.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return View(books);
        }
        public async Task<IActionResult> Details(int id)
        {
            var books = await _bookRepository.GetByBookIdAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book books)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.Create(books);
                return RedirectToAction("Index");
            }
            return View(books);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var books = await _bookRepository.GetByBookIdAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book books)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.Update(books);
                return RedirectToAction("Index");
            }
            return View(books);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var books = await _bookRepository.GetByBookIdAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Book books)
        {
            await _bookRepository.Delete(books);
            return RedirectToAction("Index");
        }
    }
}
