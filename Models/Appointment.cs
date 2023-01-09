namespace WebApplication2.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
