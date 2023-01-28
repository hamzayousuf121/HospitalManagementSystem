using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.ActionFilters;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
    [HomeActionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly HospitalContext _context;

        public HomeController(ILogger<HomeController> logger, HospitalContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.branches = _context.Branches.ToList();
            model.ImageSliders = _context.ImageSliders.ToList();
            return View(model);
        }

        public IActionResult Contact()
        {
            List<Contact> contacts = _context.Contacts.Include(x => x.Branch).ThenInclude(y => y.City).ToList();
            return View(contacts);
        }
        public IActionResult Service()
        {
            List<Service> services = _context.Services.ToList();
            return View(services);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}