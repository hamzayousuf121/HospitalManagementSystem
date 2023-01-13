namespace WebApplication2.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Degree { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public int Fees { get; set; }
        public string Designation { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual DoctorStatus DoctorStatus { get; set; }
        public int DoctorStatusId { get; set; }
        public virtual Branch Branch { get; set; }
        public int BranchId { get; set; }
        public string ImageUrl { get; set; }
        public virtual DoctorCategory DoctorCategory { get; set; }
        public int DoctorCategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
