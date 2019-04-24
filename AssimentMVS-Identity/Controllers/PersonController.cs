using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVS_Identity.Models;
using AssimentMVS_Identity.Models.Interface;
using AssimentMVS_Identity.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssimentMVS_Identity.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        //CountryVM CountryVM = new CountryVM();

        private readonly IPersonService _personService;
        private readonly ICityService _cityService;//********

        public PersonController(IPersonService personService, ICityService cityService)
        {
            _personService = personService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            //CountryVM.People = _personService.AllPersons();
            //return View(CountryVM.People);
            return View(_personService.AllPersons());
        }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                person = _personService.CreatePersonWithoutCity(person);

                return RedirectToAction(nameof(Index));
            }
            
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = _personService.FindPerson((int)id);
            if (person == null)
            {
                return NotFound();
            }
            ////********
            //PersonVM personVM = new PersonVM
            //{
            //    Id = person.Id,
            //    Name = person.Name,
            //    Age = person.Age,
            //    Cities = _cityService.AllCities(),
            //};
            ////********
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _personService.UpdatePerson(person);
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _personService.DeletePerson((int)id);
                return RedirectToAction(nameof(Index));
            }
            return Content("");            
        }
    }
}