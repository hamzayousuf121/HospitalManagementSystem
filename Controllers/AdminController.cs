using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
