using AssimentMVS_Identity.Models;
using AssimentMVS_Identity.Models.Interface;
using AssimentMVS_Identity.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssimentMVS_Identity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IPersonService _personService;

        public CityController(ICityService cityService, IPersonService personService)
        {
            _cityService = cityService;
            _personService = personService;
        }

        public ActionResult Index(int id)
        {
            var city = _cityService.FindCity(id);

            return View(city);
        }                

        public IActionResult CreatePer(int cityId)//001
        {
            var vm = new PersonVM
            {
                CityId = cityId//tar city id o koppla till person
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePer(Person person, int cityId)//001
        {
            if (ModelState.IsValid)
            {
                _personService.CreatePerson(person, cityId);
                return RedirectToAction(nameof(Details), "City", new { id = cityId });
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var city = _cityService.FindCity((int)id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(City city)
        {

            if (ModelState.IsValid)
            {
                _cityService.UpdateCity(city);//         controller Details(id) sen city country id
                return RedirectToAction(nameof(Details), "Country", new { id = city.Country.Id });
            }

            return View(city);
        }

        [HttpGet]
        public IActionResult EditPerson(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = _personService.FindPersonWithCity((int)id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPerson(Person person, int? cityId)
        {
            if (ModelState.IsValid)
            {
                _personService.UpdatePersonWithCity(person, cityId);

                return RedirectToAction(nameof(Details), "City", new { id = cityId });
            }

            return View(person);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _personService.DeletePerson((int)id);//001
                return RedirectToAction(nameof(Index));
            }
            return Content("");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var FF = _cityService.FindCity((int)id);

            if (FF == null)
            {
                return NotFound();
            }

            //CountryVM vm = new CountryVM();//001
            //vm.City = FF;
            //vm.People = FF.People;

            return View(FF);
        }
    }
}