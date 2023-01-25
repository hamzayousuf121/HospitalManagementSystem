using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
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
            List<Contact> Contacts = _context.Contacts.Include(x => x.Branch).ThenInclude(y => y.City).ToList();
            return View(Contacts);
        }
        public IActionResult Service()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}