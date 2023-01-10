using System.Numerics;

namespace WebApplication2.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientGender { get; set; }
        public int PatientAge { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
        public int BloodGroupId { get; set; }
        public string PatientEmail { get; set; }
        public double PatientPhoneNo { get; set; }
        public virtual Branch Branch { get; set; }
        public int BranchId { get; set; }
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
        public virtual DoctorCategory DoctorCategory { get; set; }
        public int DoctorCategoryId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public string? ReasonForAppointment { get; set; }
        public virtual AppointmentStatus AppointmentStatus { get; set; }
        public int AppointmentStatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
