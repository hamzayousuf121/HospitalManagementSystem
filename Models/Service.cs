namespace WebApplication2.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
