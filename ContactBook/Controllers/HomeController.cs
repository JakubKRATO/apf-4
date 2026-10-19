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


        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var contact = _contactService.GetById(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            _contactService.Add(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
             _contactService.Update(contact);
             return RedirectToAction("Index");
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

        public IActionResult Delete(int id)
        {
            var contact = _contactService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
