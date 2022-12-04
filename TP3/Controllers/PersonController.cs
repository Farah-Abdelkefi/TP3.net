using Microsoft.AspNetCore.Mvc;
using System;
using TP3.Models;

namespace TP3.Controllers
{
    public class PersonController : Controller
    {
        [Route("Person/{id:int}")]
        public IActionResult Index(int id)
        {
            Personal_info pi = new Personal_info();

            return View(pi.GetPerson(id));
        }
        [Route("Person/all")]
        public IActionResult All()
        {
            Personal_info pi = new Personal_info();

            return View(pi.GetAllPerson());
        }
        [HttpGet]
        public IActionResult Search()
        {
            ViewBag.notFound = false;
            return View();
        }
        [HttpPost]
        public IActionResult Search(String first_name, String country)
        {
            Personal_info pi = new Personal_info();
            List<Person> Persons = pi.GetAllPerson();
            foreach (Person p in Persons)
            {
                if (p.FirstName == first_name && p.Country == country)
                {
                    return Redirect(p.Id.ToString());

                }
            }
            ViewBag.notFound = true;
            return View();
        }
    }
}
