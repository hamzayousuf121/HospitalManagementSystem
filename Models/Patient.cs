namespace WebApplication2.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
        public int BloodGroupId { get; set; }
        public string Address { get; set; }

        public virtual Branch Branch { get; set; }
        public int BranchId { get; set; }
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }

        public DateTime CreatedAt { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
