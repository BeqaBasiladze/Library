using Library.DAL.Interfaces;
using Library.DAL.Repositories;
using Library.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguagesRepository _languagesRepository;
        public LanguageController(ILanguagesRepository languagesRepository)
        {
            _languagesRepository = languagesRepository;
        }
        public async Task<IActionResult> Index()
        {
            var language = await _languagesRepository.GetAllLanguages();
            return View(language);
        }
        public IActionResult Details(int id)
        {
            var language = _languagesRepository.GetLangeageById(id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Language language)
        {
            if (ModelState.IsValid)
            {
                language.CreatedBy = "";
                language.CreatedAt = DateTime.Now;
                language.ModifiedBy = "";
                language.ModifiedAt = DateTime.Now;
                language.isDelete = false;
                language.Id = 1;
                await _languagesRepository.Create(language);
                return RedirectToAction("Index");
            }
            return View(language);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var language = await _languagesRepository.GetLangeageById(id);
            if(language == null)
            {
                return NotFound();
            }
            return View(language);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Language language)
        {
            if (ModelState.IsValid)
            {
                language.CreatedBy = "";
                language.CreatedAt = DateTime.Now;
                language.ModifiedBy = "";
                language.ModifiedAt = DateTime.Now;
                language.isDelete = false;
                language.Id = 1;
                await _languagesRepository.Update(language);
                return RedirectToAction("Index");
            }
            return View(language);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var language = await _languagesRepository.GetLangeageById(id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Language language)
        {
            await _languagesRepository.Delete(language);
            return RedirectToAction("Index");
        }
    }
}
