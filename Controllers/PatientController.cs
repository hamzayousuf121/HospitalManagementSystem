using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WebApplication2.ActionFilters;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalContext _context;
        private readonly IHostEnvironment _environment;
        public PatientController(HospitalContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        { 
            return View();
        }

        [HomeActionFilter]
        public IActionResult Appointment(string doctorId, string categoryId)
        {
            ViewBag.Categories = new SelectList(_context.DoctorCategories.ToList(), "Id", "Name", categoryId);
            ViewBag.Doctors = new SelectList(_context.Doctors.ToList(), "Id", "Name", doctorId);
            ViewBag.BloodGroups = new SelectList(_context.BloodGroups.ToList(), "Id", "Name");

            return View();
        }
        [PatientActionFilter]
        public IActionResult Profile()
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "Id", "Name");
            ViewBag.BloodGroups = new SelectList(_context.BloodGroups.ToList(), "Id", "Name");

            string accessToken = Request.Cookies["user-access-token"];
            User user = _context.Users.Include(x => x.Role).Where(x => x.AccessToken == accessToken).FirstOrDefault();
            if(user is not null)
            {
                Patient patient = _context.Patients.Where(x => x.UserId == user.Id).FirstOrDefault();
                return View(patient);
            }

            return View();  
        }

        [PatientActionFilter]
        [HttpPost]
        public IActionResult AddOrUpdatePatient(Patient patient)
        {
            string accessToken = Request.Cookies["user-access-token"];
            User user = _context.Users.Where(x => x.AccessToken == accessToken).FirstOrDefault();
            var file = Request.Form.Files["ImageUrl"];
            if (file is not null)
            {
                patient.ImageUrl = $"{DateTime.UtcNow.Ticks}.jpg";
                var path = $"{_environment.ContentRootPath}/wwwroot/assets/img/{patient.ImageUrl}";
                file.CopyTo(new FileStream(path, FileMode.Create));
            }
             
            patient.UserId = user.Id;
            _context.Patients.Update(patient);
            _context.SaveChanges();
            return Redirect("/Home/Index");
        }
    }
}
