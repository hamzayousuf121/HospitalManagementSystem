using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Branch")]
        public string Name { get; set; }
        public virtual City City { get; set; }
        [Required]
        public int CityId { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
