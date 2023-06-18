using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Library.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public async Task<IActionResult> Index()
        {
            var publisher = await _publisherRepository.GetAllPublishers();
            return View(publisher);
        }
        public IActionResult Details(int id)
        {
            var publisher = _publisherRepository.GetPublisherById(id);
            if(publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Publisher publisher)
        {
            if(ModelState.IsValid)
            {
                publisher.CreatedBy = "";
                publisher.CreatedAt = DateTime.Now;
                publisher.ModifiedBy = "";
                publisher.ModifiedAt = DateTime.Now;
                publisher.isDelete = false;
                await _publisherRepository.Create(publisher);
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var publisher = await _publisherRepository.GetPublisherById(id);
            if(publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Publisher publisher)
        {
            if(ModelState.IsValid)
            {
                await _publisherRepository.Update(publisher);
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var publisher = await _publisherRepository.GetPublisherById(id);
            if(publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Publisher publisher)
        {
            await _publisherRepository.Delete(publisher);
            return RedirectToAction("Index");
        }
    }
}
