using Library.DAL.Interfaces;
using Library.DAL.Repositories;
using Library.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionRepository _positionRepository;
        public PositionController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        public async Task<IActionResult> Index()
        {
            var position = await _positionRepository.GetAllPositions();
            return View(position);
        }
        public IActionResult Details(int id)
        {
            var position = _positionRepository.GetPositionById(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Position position)
        {
            if (ModelState.IsValid)
            {
                position.CreatedBy = "";
                position.ModifiedBy = "";
                position.ModifiedAt = DateTime.Now;
                position.IsDeleted = false;
                position.Id = 1;
                await _positionRepository.Create(position);
                return RedirectToAction("Index");
            }
            return View(position);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var position = await _positionRepository.GetPositionById(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Position position)
        {
            if (ModelState.IsValid)
            {
                position.CreatedBy = "";
                position.ModifiedBy = "";
                position.ModifiedAt = DateTime.Now;
                position.IsDeleted = false;
                position.Id = 1;
                await _positionRepository.Update(position);
                return RedirectToAction("Index");
            }
            return View(position);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var position = await _positionRepository.GetPositionById(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Position position)
        {
            await _positionRepository.Delete(position);
            return RedirectToAction("Index");
        }
    }
}
