using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DoctorController : Controller
    {
        public readonly HospitalContext _context;

        public DoctorController(HospitalContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Doctor()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Schedule()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Schedule(Schedule Schedule)
        {
           _context.Schedules.Update(Schedule);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Appointment()
        {
            return View();
        }
    }
}
