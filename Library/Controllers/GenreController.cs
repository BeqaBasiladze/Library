using Library.DAL.Interfaces;
using Library.DAL.Repositories;
using Library.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _genreRepository.GetAllGenresAsync();
            return View(genres);
        }
        public IActionResult Details(int id)
        {
            var genres = _genreRepository.GetByGenreIdAsync(id);
            if (genres== null)
            {
                return NotFound();
            }
            return View(genres);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Genre genres)
        {
            if (ModelState.IsValid)
            {
                await _genreRepository.Create(genres);
                return RedirectToAction("Index");
            }
            return View(genres);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var genres = await _genreRepository.GetByGenreIdAsync(id);
            if (genres == null)
            {
                return NotFound();
            }
            return View(genres);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Genre genres)
        {
            if (ModelState.IsValid)
            {
                await _genreRepository.Update(genres);
                return RedirectToAction("Index");
            }
            return View(genres);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var genres = await _genreRepository.GetByGenreIdAsync(id);
            if (genres == null)
            {
                return NotFound();
            }
            return View(genres);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Genre genres)
        {
            await _genreRepository.Delete(genres);
            return RedirectToAction("Index");
        }
    }
}
