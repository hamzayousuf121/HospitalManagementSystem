using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WebApplication2.ActionFilters;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DoctorController : Controller
    {
        public readonly HospitalContext _context;
        public readonly IHostEnvironment _environment;

        public DoctorController(HospitalContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public Doctor GetDoctorById(int Id)
        {
            Doctor doctor = _context.Doctors.Include(x => x.DoctorStatus).Include(x => x.DoctorCategory).Where(x => x.Id == Id).FirstOrDefault();
            return doctor;
        }
        public IActionResult Doctor()
        {
            ViewBag.Categories = new SelectList(_context.DoctorCategories.ToList(), "Id", "Name");
            List<Doctor> doctors = _context.Doctors.Include(x=> x.DoctorStatus).Include(x => x.DoctorCategory).ToList();
            return View(doctors);
        }

        public IActionResult ScheduleById(int id)
        {
            List<Schedule> Schedules = _context.Schedules.Where(x => x.DoctorId == id).Include(x => x.WeekDay).Include(x => x.Doctor).ToList();
            return Json(Schedules);
        }
        [DoctorActionFilter]
        public IActionResult Schedule()
        {
            string accessToken = Request.Cookies["user-access-token"];

            User user = _context.Users.Where(x => x.AccessToken == accessToken).FirstOrDefault();

            Doctor doctor = _context.Doctors.Where(x => x.UserId == user.Id).FirstOrDefault();

            if (user is not null && doctor is not null)
            {
                List<Schedule> Schedules = _context.Schedules.Where(x => x.DoctorId == doctor.Id).Include(x => x.WeekDay).Include(x => x.Doctor).ToList();
                return View(Schedules);
            }

            return View();
        }
        [DoctorActionFilter]

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
                Schedule Schedule = _context.Schedules.Where(x => x.Id == id).FirstOrDefault();
                return View(Schedule);
            }

        }
        [DoctorActionFilter]
        [HttpPost]
        public IActionResult AddOrUpdateSchedule(Schedule schedule)
        {
            string accessToken = Request.Cookies["user-access-token"];
            User user = _context.Users.Where(x => x.AccessToken == accessToken).FirstOrDefault();
            Doctor doctor = _context.Doctors.Where(x => x.UserId == user.Id).FirstOrDefault();

            if (doctor is not null)
            {
                schedule.DoctorId = doctor.Id;
                schedule.CreatedOn = DateTime.Now;
                _context.Schedules.Update(schedule);
                _context.SaveChanges();
                return Redirect("/Doctor/Schedule");
            }

            ViewBag.Error = "Please Create Doctor Profile First";
            return Redirect("/Doctor/Schedule");
        }
        [DoctorActionFilter]
        public IActionResult DeleteSchedule(int id)
        {
            Schedule schedule = _context.Schedules.Where(x => x.Id == id).FirstOrDefault();
            if (schedule is not null)
            {
                _context.Schedules.Remove(schedule);
                _context.SaveChanges();
            }
            return Redirect("/Doctor/Schedule");

        }

        [DoctorActionFilter]
        public IActionResult Profile()
        {
            ViewBag.DoctorStatuses = new SelectList(_context.DoctorStatuses.ToList(), "Id", "Name");
            ViewBag.DoctorCategories = new SelectList(_context.DoctorCategories.ToList(), "Id", "Name");
            ViewBag.Branches = new SelectList(_context.Branches.ToList(), "Id", "Name");

            string accessToken = Request.Cookies["user-access-token"];

            User user = _context.Users.Include(x => x.Role).Where(x => x.AccessToken == accessToken).FirstOrDefault();
            if(user is not null)
            {
                Doctor doctor = _context.Doctors.Where(x => x.UserId == user.Id).FirstOrDefault();
                return View(doctor); 
            }

            return View();
        }
        
        [DoctorActionFilter]
        [HttpPost]
        public IActionResult AddOrUpdateProfile(Doctor doctor)
        {
            string accessToken = Request.Cookies["user-access-token"];
            User user = _context.Users.Where(x => x.AccessToken == accessToken).FirstOrDefault();

            var file = Request.Form.Files["ImageUrl"];
            if (file is not null)
            {
                doctor.ImageUrl = $"{DateTime.UtcNow.Ticks}.jpg";
                var path = $"{_environment.ContentRootPath}/wwwroot/assets/img/{doctor.ImageUrl}";
                file.CopyTo(new FileStream(path, FileMode.Create));
            }

            doctor.UserId = user.Id;

            _context.Doctors.Update(doctor);
            _context.SaveChanges();
            return Redirect("/Home/Index");
        }
        [DoctorActionFilter]
        public IActionResult ChangeAppointmentStatus(int Id, int appointmentStatusId)
        {
            Appointment appointment = _context.Appointments.Where(x => x.Id == Id).FirstOrDefault();
            appointment.AppointmentStatusId = appointmentStatusId;
            _context.SaveChanges();
            return Redirect("/Doctor/Appointment");
        }
        
        [DoctorActionFilter]
        [HttpGet]
        public IActionResult Appointment()
        {
            List<Appointment> appointments;
            string accessToken = Request.Cookies["user-access-token"];

            User user = _context.Users.Include(x => x.Role).Where(x => x.AccessToken == accessToken).FirstOrDefault();

            Doctor doctor = _context.Doctors.Where(x => x.UserId == user.Id).FirstOrDefault();

            if (doctor is not null)
            {
                appointments = _context.Appointments.Include(x => x.BloodGroup).Include(x => x.AppointmentStatus).Include(x => x.Doctor).Include(x => x.DoctorCategory).Where(x => x.DoctorId == doctor.Id).ToList();
                return View(appointments);
            }

            appointments = _context.Appointments.Include(x => x.BloodGroup).Include(x => x.AppointmentStatus).Include(x => x.Doctor).Include(x => x.DoctorCategory).ToList();
            return View(appointments);
        }
        [HomeActionFilter]
        [HttpPost]
        public IActionResult AddOrUpdateAppointment(Appointment appointment)
        {
            appointment.AppointmentStatusId = 4;
            appointment.CreatedAt = DateTime.Now;
            _context.Appointments.Update(appointment);
            _context.SaveChanges();

            return Redirect("/Home/Index");
        }
    }
}
