using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Global turn off delete behaviour on foreign keys
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ImageSlider> ImageSliders { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorStatus> DoctorStatuses { get; set; }
        public DbSet<DoctorCategory> DoctorCategories { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

    }
}