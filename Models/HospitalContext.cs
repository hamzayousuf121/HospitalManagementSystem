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

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<AddressDetail> AddressDetail { get; set; }
        public DbSet<ImageSlider> ImageSlider { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatus { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<DoctorStatus> DoctorStatus { get; set; }
        public DbSet<DoctorCategory> DoctorCategory { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<BloodGroup> BloodGroup { get; set; }
        public DbSet<WeekDays> WeekDays { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Schedule> Schedule { get; set; }

    }
}