using System.Diagnostics;
using ContactBook.Models;
using ContactBook.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService _contactService;

        public HomeController(ILogger<HomeController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var contacts = _contactService.GetAll();
            return View(contacts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _contactService.Add(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        
        public IActionResult Detail(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null)
            {
                return View("Index");
            }
            return View(contact);
        }

    }
}
