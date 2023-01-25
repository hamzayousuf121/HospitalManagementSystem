using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Categories = new SelectList(_context.DoctorCategories.ToList(), "Id", "Name") ;
            return View();
        }
        [HttpGet]
        public IActionResult Schedule(int id)
        {
            Schedule Schedules = _context.Schedules.Where(x => x.Id == id).FirstOrDefault();
            return View(Schedules);
        }

        [HttpGet]
        public IActionResult AddOrUpdateSchedule(int id)
        {
            ViewBag.Weekdays = new SelectList(_context.WeekDays.ToList(), "Id", "Name");

            if (id == 0)
            {
                return View();
            }
            else
            {
               Schedule Schedule = _context.Schedules.Where(x=> x.Id == id).FirstOrDefault();
                return View(Schedule);
            }
          
        }
        [HttpPost]
        public IActionResult AddOrUpdateSchedule(Schedule Schedule)
        {
            _context.Schedules.Update(Schedule);
            _context.SaveChanges();
            return Redirect("/Doctor/Schedule");
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
