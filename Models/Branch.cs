namespace WebApplication2.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual City City { get; set; }
        public int CityId { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
