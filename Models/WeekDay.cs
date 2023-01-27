using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class WeekDay
    {
        public int Id { get; set; }
        [Required]
        [Display(Name= "Week Day")]
        public string Name { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
