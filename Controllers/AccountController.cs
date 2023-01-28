using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.ActionFilters;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
      
        private readonly HospitalContext _context;
        public AccountController(HospitalContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AccountActionFilter]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User User)
        {
            User DbUser = _context.Users.Where(x => x.Email.ToLower().Equals(User.Email) && x.Password.Equals(User.Password)).FirstOrDefault();
            if (DbUser is null)
            {
                ViewBag.ErrorMessage = "Email and Password is incorrect";
                return View();
            }
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Append("user-access-token", DbUser.AccessToken, cookieOptions);
            return Redirect("/Home/Index");
        }
        [AccountActionFilter]
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(_context.Roles.Where(x => x.Name != "Admin").ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Register(User User)
        {
            User userExist = _context.Users.Where(x => x.Email.ToLower().Equals(User.Email)).FirstOrDefault();
            if (userExist is not null)
            {
                ViewBag.ErrorMessage = "This Email is already Exist";
                return View();
            }

            User.AccessToken = Guid.NewGuid().ToString();
            User.JoinOn = DateTime.Today;
            _context.Users.Add(User);
            _context.SaveChanges();

            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Append("user-access-token", User.AccessToken, cookieOptions);
            return Redirect("/Home/Index");
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("user-access-token");
            return Redirect("/Account/Login");
        }
    }
}
