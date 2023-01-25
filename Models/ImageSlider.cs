using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ImageSlider
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
