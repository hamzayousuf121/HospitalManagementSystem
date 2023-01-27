using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Numerics;
using WebApplication2.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        private readonly HospitalContext _context;
        private readonly IHostEnvironment _environment;

        public AdminController(HospitalContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImageSliders()
        {
            List<ImageSlider> imageSlider = _context.ImageSliders.ToList();
            return View(imageSlider);
        }
        [HttpGet]
        public IActionResult AddOrUpdateImageSlider(int id)
        {

            if (id == 0)
            {
                return View();
            }
            else
            {
                ImageSlider imageSlider = _context.ImageSliders.Where(x => x.Id == id).FirstOrDefault();
                return View(imageSlider);

            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateImageSlider(ImageSlider imageSlider)
        {
            var file = Request.Form.Files["imageSlider"];
            if (file is not null)
            {
                imageSlider.Url = $"{DateTime.UtcNow.Ticks}.jpg";
                var path = $"{_environment.ContentRootPath}/wwwroot/assets/img/{imageSlider.Url}";
                file.CopyTo(new FileStream(path, FileMode.Create));
            } 
            _context.ImageSliders.Update(imageSlider);
            _context.SaveChanges();
            return Redirect("/Admin/ImageSliders");
        }

        public IActionResult DeleteImageSlider(int id)
        {
            ImageSlider imageSlider = _context.ImageSliders.Where(x => x.Id == id).FirstOrDefault();
            if (imageSlider is not null)
            {
                _context.ImageSliders.Remove(imageSlider);
                _context.SaveChanges();
            }

            return Redirect("/Admin/ImageSliders");
        }
        public IActionResult Contacts()
        {
            List<Contact> contacts = _context.Contacts.Include(x => x.Branch).ToList();
            return View(contacts);
        }
        [HttpGet]
        public IActionResult AddOrUpdateContact(int id)
        {
            ViewBag.Branches = new SelectList(_context.Branches.ToList(), "Id", "Name");

            if (id == 0)
            {
                return View();
            }
            else
            {
                Contact contact = _context.Contacts.Where(x => x.Id == id).FirstOrDefault();
                return View(contact);
            }
        }
        [HttpPost]
        public IActionResult AddOrUpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Redirect("/Admin/Contacts");
        }
        public IActionResult DeleteContact(int id)
        {
            Contact contact = _context.Contacts.Where(x => x.Id == id).FirstOrDefault();
            if (contact is not null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }

            return Redirect("/Admin/Contacts");
        }

        public IActionResult BloodGroups()
        {
            List<BloodGroup> bloodGroup = _context.BloodGroups.ToList();
            return View(bloodGroup);
        }
        [HttpGet]
        public IActionResult AddOrUpdateBloodGroup(int id)
        {

            if (id == 0)
            {
                return View();
            }
            else
            {
                BloodGroup bloodGroup = _context.BloodGroups.Where(x => x.Id == id).FirstOrDefault();
                return View(bloodGroup);

            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateBloodGroup(BloodGroup bloodGroup)
        {
            _context.BloodGroups.Update(bloodGroup);
            _context.SaveChanges();
            return Redirect("/Admin/BloodGroups");
        }

        public IActionResult DeleteBloodGroup(int id)
        {
            BloodGroup bloodGroup = _context.BloodGroups.Where(x => x.Id == id).FirstOrDefault();
            if (bloodGroup is not null)
            {
                _context.BloodGroups.Remove(bloodGroup);
                _context.SaveChanges();
            }

            return Redirect("/Admin/bloodGroups");
        }

        public IActionResult WeekDays()
        {
            List<WeekDay> weekDays = _context.WeekDays.ToList();
            return View(weekDays);
        }

        [HttpGet]
        public IActionResult AddOrUpdateWeekDay(int id)
        {

            if (id == 0)
            {
                return View();
            }
            else
            {
                WeekDay weekDay = _context.WeekDays.Where(x => x.Id == id).FirstOrDefault();
                return View(weekDay);

            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateWeekDay(WeekDay weekDay)
        {
            _context.WeekDays.Update(weekDay);
            _context.SaveChanges();
            return Redirect("/Admin/WeekDays");
        }

        public IActionResult DeleteWeekDay(int id)
        {
            WeekDay weekDay = _context.WeekDays.Where(x => x.Id == id).FirstOrDefault();
            if (weekDay is not null)
            {
                _context.WeekDays.Remove(weekDay);
                _context.SaveChanges();
            }

            return Redirect("/Admin/WeekDays");
        }

        public IActionResult Cities()
        {
            List<City> cities = _context.Cities.ToList();
            return View(cities);
        }

        [HttpGet]
        public IActionResult AddOrUpdateCity(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                City city = _context.Cities.Where(x => x.Id == id).FirstOrDefault();
                return View(city);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateCity(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
            return Redirect("/Admin/Cities");
        }

        public IActionResult DeleteCity(int id)
        {
            City city = _context.Cities.Where(x => x.Id == id).FirstOrDefault();
            if (city is not null)
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();
            }
            return Redirect("/Admin/cities");
        }
        public IActionResult Roles()
        {
            List<Role> roles = _context.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddOrUpdateRole(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                Role role = _context.Roles.Where(x => x.Id == id).FirstOrDefault();
                return View(role);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return Redirect("/Admin/Roles");
        }

        public IActionResult DeleteRole(int id)
        {
            Role role = _context.Roles.Where(x => x.Id == id).FirstOrDefault();
            if (role is not null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
            return Redirect("/Admin/Roles");
        }

        public IActionResult Appointments()
        {
            Console.WriteLine(HttpContext.Request);

            List<Appointment> appointments = _context.Appointments.Include(x=> x.BloodGroup).Include(x=> x.AppointmentStatus).Include(x => x.Doctor).Include(x => x.DoctorCategory).ToList();
            return View(appointments);
        }

        [HttpGet] 
        public IActionResult AddOrUpdateAppointment(int id)
        {
            ViewBag.Categories = new SelectList(_context.DoctorCategories.ToList(), "Id", "Name");
            ViewBag.Doctors = new SelectList(_context.Doctors.ToList(), "Id", "Name");
            ViewBag.BloodGroups = new SelectList(_context.BloodGroups.ToList(), "Id", "Name");

            if (id == 0)
            {
                return View();
            }
            else
            {
                Appointment appointment = _context.Appointments.Where(x => x.Id == id).FirstOrDefault();
                return View(appointment);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateAppointment(Appointment appointment)
        {
            appointment.AppointmentStatusId = 4;
            appointment.CreatedAt= DateTime.Now;
            _context.Appointments.Update(appointment);
            _context.SaveChanges();

            return Redirect("/Admin/Appointments");
        }

        public IActionResult DeleteAppointment(int id)
        {
            Appointment appointment = _context.Appointments.Where(x => x.Id == id).FirstOrDefault();
            if (appointment is not null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
            return Redirect("/Admin/Appointments");
        }

        public IActionResult ChangeAppointmentStatus(int Id, int appointmentStatusId)
        {
          Appointment appointment =  _context.Appointments.Where(x => x.Id == Id).FirstOrDefault();
            appointment.AppointmentStatusId = appointmentStatusId;
            _context.SaveChanges();
           return Redirect("/Doctor/Appointment");
        }
        public IActionResult AppointmentStatuses()
        {
            List<AppointmentStatus> appointmentStatuses = _context.AppointmentStatuses.ToList();
            return View(appointmentStatuses);
        }

        [HttpGet]
        public IActionResult AddOrUpdateAppointmentStatus(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                AppointmentStatus appointmentStatus = _context.AppointmentStatuses.Where(x => x.Id == id).FirstOrDefault();
                return View(appointmentStatus);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateAppointmentStatus(AppointmentStatus appointmentStatus)
        {
            _context.AppointmentStatuses.Update(appointmentStatus);
            _context.SaveChanges();
            return Redirect("/Admin/AppointmentStatuses");
        }

        public IActionResult DeleteAppointmentStatus(int id)
        {
            AppointmentStatus appointmentStatus = _context.AppointmentStatuses.Where(x => x.Id == id).FirstOrDefault();
            if (appointmentStatus is not null)
            {
                _context.AppointmentStatuses.Remove(appointmentStatus);
                _context.SaveChanges();
            }
            return Redirect("/Admin/AppointmentStatuses");
        }
        public IActionResult DoctorStatuses()
        {
            List<DoctorStatus> doctorStatuses = _context.DoctorStatuses.ToList();
            return View(doctorStatuses);
        }

        [HttpGet]
        public IActionResult AddOrUpdateDoctorStatus(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DoctorStatus doctorStatus = _context.DoctorStatuses.Where(x => x.Id == id).FirstOrDefault();
                return View(doctorStatus);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateDoctorStatus(DoctorStatus doctorStatus)
        {
            _context.DoctorStatuses.Update(doctorStatus);
            _context.SaveChanges();
            return Redirect("/Admin/DoctorStatuses");
        }

        public IActionResult DeleteDoctorStatus(int id)
        {
            DoctorStatus doctorStatus = _context.DoctorStatuses.Where(x => x.Id == id).FirstOrDefault();
            if (doctorStatus is not null)
            {
                _context.DoctorStatuses.Remove(doctorStatus);
                _context.SaveChanges();
            }
            return Redirect("/Admin/DoctorStatuses");
        }

        public IActionResult DoctorCategories()
        {
            List<DoctorCategory> doctorCategory = _context.DoctorCategories.ToList();
            return View(doctorCategory);
        }

        [HttpGet]
        public IActionResult AddOrUpdateDoctorCategory(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DoctorCategory doctorCategory = _context.DoctorCategories.Where(x => x.Id == id).FirstOrDefault();
                return View(doctorCategory);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateDoctorCategory(DoctorCategory doctorCategory)
        {
            _context.DoctorCategories.Update(doctorCategory);
            _context.SaveChanges();
            return Redirect("/Admin/DoctorCategories");
        }

        public IActionResult DeleteDoctorCategory(int id)
        {
            DoctorCategory doctorCategory = _context.DoctorCategories.Where(x => x.Id == id).FirstOrDefault();
            if (doctorCategory is not null)
            {
                _context.DoctorCategories.Remove(doctorCategory);
                _context.SaveChanges();
            }
            return Redirect("/Admin/DoctorCategories");
        }

        public IActionResult Branches()
        {
            List<Branch> branches = _context.Branches.Include(x => x.City).ToList();
            return View(branches);
        }

        [HttpGet]
        public IActionResult AddOrUpdateBranch(int id)
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "Id", "Name");
            if (id == 0)
            {
                return View();
            }
            else
            {
                Branch branch = _context.Branches.Where(x => x.Id == id).FirstOrDefault();
                return View(branch);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateBranch(Branch branch)
        {
            _context.Branches.Update(branch);
            _context.SaveChanges();
            return Redirect("/Admin/Branches");
        }

        public IActionResult DeleteBranch(int id)
        {
            Branch branch = _context.Branches.Where(x => x.Id == id).FirstOrDefault();
            if (branch is not null)
            {
                _context.Branches.Remove(branch);
                _context.SaveChanges();
            }
            return Redirect("/Admin/Branches");
        }

        public IActionResult Users()
        {
            List<User> users = _context.Users.Include(x => x.Role).ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddOrUpdateUser(int id)
        {
            ViewBag.Roles = new SelectList(_context.Roles.ToList(), "Id", "Name");
            if (id == 0)
            {
                return View();
            }
            else
            {
                User user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateUser(User user)
        {
            user.AccessToken = Guid.NewGuid().ToString();
            user.JoinOn = DateTime.Today;
           
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Append("user-access-token", user.AccessToken, cookieOptions);

            _context.Users.Update(user);
            _context.SaveChanges();
            return Redirect("/Admin/Users");
        }

        public IActionResult DeleteUser(int id)
        {
            User user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user is not null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return Redirect("/Admin/Users");
        }

        public IActionResult Doctors()
        {
            List<Doctor> doctors = _context.Doctors.Include(x=> x.DoctorStatus).Include(x=> x.DoctorCategory).ToList();
            return View(doctors);
        }

        [HttpGet]
        public IActionResult AddOrUpdateDoctor(int id)
        {
            ViewBag.DoctorStatuses = new SelectList(_context.DoctorStatuses.ToList(), "Id", "Name");
            ViewBag.DoctorCategories = new SelectList(_context.DoctorCategories.ToList(), "Id", "Name");
            ViewBag.Branches = new SelectList(_context.Branches.ToList(), "Id", "Name");

            if (id == 0)
            {
                return View();
            }
            else
            {
                Doctor doctor = _context.Doctors.Where(x => x.Id == id).FirstOrDefault();
                return View(doctor);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateDoctor(Doctor doctor)
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
            return Redirect("/Admin/Doctors");
        }

        public IActionResult DeleteDoctor(int id)
        {
            Doctor doctor = _context.Doctors.Where(x => x.Id == id).FirstOrDefault();
            if (doctor is not null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
            return Redirect("/Admin/Doctors");
        }

        public IActionResult Patients()
        {
            List<Patient> patients = _context.Patients.Include(x => x.City).Include(x => x.BloodGroup).ToList();
            return View(patients);
        }

        [HttpGet]
        public IActionResult AddOrUpdatePatient(int id)
        {
            ViewBag.Cities = new SelectList(_context.Cities.ToList(), "Id", "Name");
            ViewBag.BloodGroups = new SelectList(_context.BloodGroups.ToList(), "Id", "Name");
            if (id == 0)
            {
                return View();
            }
            else
            {
                Patient patient = _context.Patients.Where(x => x.Id == id).FirstOrDefault();
                Console.WriteLine("Test");
                return View(patient);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdatePatient(Patient patient)
        {
            string accessToken = Request.Cookies["user-access-token"];
            User user = _context.Users.Where(x => x.AccessToken == accessToken).FirstOrDefault();
            var file = Request.Form.Files["ImageUrl"];
           
            if(file is not null)
            {
                patient.ImageUrl = $"{DateTime.UtcNow.Ticks}.jpg";
                var path = $"{_environment.ContentRootPath}/wwwroot/assets/img/{patient.ImageUrl}";
                file.CopyTo(new FileStream(path, FileMode.Create));
            }

            patient.UserId = user.Id;
            _context.Patients.Update(patient);
            _context.SaveChanges();
            return Redirect("/Admin/Patients");
        }

        public IActionResult DeletePatient(int id)
        {
            Patient patient = _context.Patients.Where(x => x.Id == id).FirstOrDefault();
            if (patient is not null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
            return Redirect("/Admin/Patients");
        }

        public IActionResult Services()
        {
            List<Service> services = _context.Services.ToList();
            return View(services);
        }

        [HttpGet]
        public IActionResult AddOrUpdateService(int id)
        {

            if (id == 0)
            {
                return View();
            }
            else
            {
                Service service = _context.Services.Where(x => x.Id == id).FirstOrDefault();
                return View(service);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateService(Service service)
        {
            var file = Request.Form.Files["serviceImage"];

            if (file is not null)
            {
                service.ImageUrl = $"{DateTime.UtcNow.Ticks}.jpg";
                string path = $"{_environment.ContentRootPath}/wwwroot/assets/img/{service.ImageUrl}";
                file.CopyTo(new FileStream(path, FileMode.Create));
            }
           
            _context.Services.Update(service);
            _context.SaveChanges();
            return Redirect("/Admin/Services");
        }

        public IActionResult DeleteService(int id)
        {
            Service service = _context.Services.Where(x => x.Id == id).FirstOrDefault();
            if (service is not null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
            return Redirect("/Admin/Services");
        }

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
                Schedule Schedule = _context.Schedules.Where(x => x.Id == id).FirstOrDefault();
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
        public IActionResult DeleteSchedule(int id)
        {
            Schedule Schedule = _context.Schedules.Where(x => x.Id == id).FirstOrDefault();
            if (Schedule != null)
            {
                _context.Schedules.Remove(Schedule);
                _context.SaveChanges();

            }
            return Redirect("/Doctor/Schedule");
        }
    }
}
