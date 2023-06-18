using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;
        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IActionResult> Index()
        {
            var address = await _addressRepository.GetAllAddresses();
            return View(address);
        }
        public async Task<IActionResult> Details(int id)
        {
            var address = await _addressRepository.GetAddressById(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Address address)
        {
            if (ModelState.IsValid)
            {
                address.CreatedBy = "";
                address.CreatedAt = DateTime.Now;
                address.ModifiedBy = "";
                address.ModifiedAt = DateTime.Now;
                address.isDelete = false;
                address.Id = 1;
                await _addressRepository.Create(address);
                return RedirectToAction("Index");
            }
            return View(address);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var address = await _addressRepository.GetAddressById(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                await _addressRepository.Update(address);
                return RedirectToAction("Index");
            }
            return View(address);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var address = await _addressRepository.GetAddressById(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Address address)
        {
            await _addressRepository.Delete(address);
            return RedirectToAction("Index");
        }
    }
}
