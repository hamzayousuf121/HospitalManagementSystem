using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Description { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
