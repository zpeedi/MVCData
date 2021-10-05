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
        public IActionResult Search(string searchString)
        {
            PeopleViewModel search = service.All();
            search.SearchString = searchString;
            if (String.IsNullOrEmpty(search.SearchString))
            {
                return PartialView("_People", service.All());
            }
            else
            {
                return PartialView("_People", service.FindBy(search));

            }
        }
        [HttpGet]
        public IActionResult PeopleList()
        {
            return PartialView("_People", service.All());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            System.Diagnostics.Debug.WriteLine("Details " + id);
            return PartialView("_Details", service.All());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            System.Diagnostics.Debug.WriteLine("Delete " + id);
            return PartialView("_Delete", service.All());
        }
        [HttpGet]
        public IActionResult People()
        {
            return View("People");
        }
        /*
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
        }*/
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
