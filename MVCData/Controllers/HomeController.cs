using Microsoft.AspNetCore.Mvc;
using MVCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    public class HomeController : Controller
    {
        IPeopleService service;

        public HomeController()
        {
            service = new PeopleService();

        }
        [HttpGet]
        public IActionResult People()
        {
            return View("People",service.All());
        }
        [HttpPost]
        public IActionResult People(PeopleViewModel peopleViewModel)
        {

            PeopleViewModel search = service.All();
            search.SearchString = peopleViewModel.SearchString;
            if (String.IsNullOrEmpty(search.SearchString))
            {
                return View("People", service.All());
            }
            else
            {
                return View("People", service.FindBy(search));

            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("People", service.All());
        }
        [HttpPost]
        public IActionResult Create(PeopleViewModel peopleViewModel)
        {


            if (ModelState.IsValid)
            {
                service.Add(peopleViewModel.CreatePersonViewModel);               
                return RedirectToAction("People");
            }
            else
            {               
                return RedirectToAction("People");
            }
        }
    }
}
