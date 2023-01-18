using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Phone]
        public double  PhoneNumber { get; set; }
        public string AccessToken { get; set; }
        public DateTime JoinOn { get; set; }
        public virtual Role Role { get; set; }
        [Required]
        public int RoleId { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
