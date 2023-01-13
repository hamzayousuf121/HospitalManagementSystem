using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
