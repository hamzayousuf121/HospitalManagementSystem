using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Appointment()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();  
        }
    }
}
