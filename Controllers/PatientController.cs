using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalContext _context;
        public PatientController(HospitalContext context) {
            _context = context; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Appointment()
        {
            ViewBag.BloodGroups = new SelectList(_context.BloodGroups.ToList(),"Id", "Name");
            return View();
        }
        public IActionResult Profile()
        {
            return View();  
        }
    }
}
