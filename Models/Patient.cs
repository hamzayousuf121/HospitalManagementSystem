using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        
        public string? ImageUrl { get; set; }
        public virtual User User { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
        [Required]
        public int BloodGroupId { get; set; }
        [Required]
        public string Address { get; set; }
        public virtual City City { get; set; }
        [Required]
        public int CityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
