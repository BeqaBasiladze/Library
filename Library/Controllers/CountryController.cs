using Library.DAL.Interfaces;
using Library.Domain.Entity;
using Library.Domain.ViewModel.Country;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var country = await _countryRepository.GetAllCountries();
            var countryViewModels = country.Select(c => new CountryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
            }).ToList();
            return View(countryViewModels);
        }
        public async Task<IActionResult> Details(int id)
        {
            var country = await _countryRepository.GetCountryById(id);
            if(country == null)
            {
                return NotFound();
            }
            return View(country);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryViewModel countryViewModel)
        {
            if(ModelState.IsValid)
            {
                var country = new Country
                {
                    Name = countryViewModel.Name,
                    Code = countryViewModel.Code,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "",
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = "",
                    Id = 1
                };
                await _countryRepository.Create(country);
                return RedirectToAction("Index");
            }
            return View(countryViewModel);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var country = await _countryRepository.GetCountryById(id);
            if(country == null)
            {
                return NotFound();
            }
            return View(country);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Country country)
        {
            if(ModelState.IsValid)
            {
                country.Id = 1;
                country.Name = country.Name;
                country.Code = country.Code;
                country.CreatedAt = DateTime.Now;
                country.ModifiedAt = DateTime.Now;
                country.ModifiedBy = "";
                country.CreatedBy = "";
                await _countryRepository.Update(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _countryRepository.GetCountryById(id);
            if(country == null)
            {
                return NotFound();
            }
            return View(country);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Country country)
        {
            await _countryRepository.Delete(country);
            return RedirectToAction("Index");
        }
    }
}
