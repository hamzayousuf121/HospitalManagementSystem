using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User User)
        {
            if (ModelState.IsValid)
            { //checking model state

                //update student to db

                return RedirectToAction("Login");
            }
            Console.WriteLine(User);
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
