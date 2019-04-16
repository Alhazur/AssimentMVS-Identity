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
        public IActionResult CreatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                person = _personService.CreatePerson(person.Name, person.Age);
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        [HttpGet]
        public IActionResult EditPerson(int? id)
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

            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                _personService.UpdatePerson(person);
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }
    }
}