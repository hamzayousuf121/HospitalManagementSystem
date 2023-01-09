namespace WebApplication2.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
