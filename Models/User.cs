namespace WebApplication2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double PhoneNumber { get; set; }
        public string AccessToken { get; set; }
        public DateTime JoinOn { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
