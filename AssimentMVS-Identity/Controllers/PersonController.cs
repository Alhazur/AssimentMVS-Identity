using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVS_Identity.Models;
using AssimentMVS_Identity.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssimentMVS_Identity.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            return View(_personService.AllPersons());
        }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult CreatePerson(Person person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        person = _personService.CreatePerson(person.Name, person.Age);

        //        return PartialView("_Person", person);
        //    }

        //    return View(person);
        //}

        public IActionResult Person(Person person)
        {
            if (ModelState.IsValid)
            {
                var item = _personService.FindPerson((int)person.Id);

                return PartialView("_Person", item);
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
            var person = _personService.FindPerson((int)id);
            if (person == null)
            {
                return NotFound();
            }

            return PartialView("_Edit", person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _personService.UpdatePerson(person);
                return PartialView("_Edit", person);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}