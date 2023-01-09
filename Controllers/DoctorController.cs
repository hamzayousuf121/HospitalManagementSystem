using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
