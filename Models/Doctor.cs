using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Fees { get; set; }
        [Required]
        public string Designation { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual DoctorStatus DoctorStatus { get; set; }
        [Required]
        public int DoctorStatusId { get; set; }
        public virtual Branch Branch { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public virtual DoctorCategory DoctorCategory { get; set; }
        [Required]
        public int DoctorCategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
