using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class DoctorCategory
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Doctor Category")]
        public string Name { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
