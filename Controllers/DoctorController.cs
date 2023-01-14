using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Doctor()
        {
            return View();
        }

        public IActionResult Schedule()
        {
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
