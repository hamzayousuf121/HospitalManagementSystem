using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string PatientGender { get; set; }
        [Required]
        public int PatientAge { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
        [Required]
        public int BloodGroupId { get; set; }
        [Required]
        public string PatientEmail { get; set; }
        [Required]
        public double PatientPhoneNo { get; set; }
        public virtual Branch Branch { get; set; }
        public int BranchId { get; set; }
        public virtual DoctorCategory DoctorCategory { get; set; }
        [Required]
        public int DoctorCategoryId { get; set; }
        public virtual Doctor Doctor { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public string? ReasonForAppointment { get; set; }
        public virtual AppointmentStatus AppointmentStatus { get; set; }
        [Required]
        public int AppointmentStatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
