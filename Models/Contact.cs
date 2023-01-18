using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual Branch Branch { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Required]
        public string AddressDetails { get; set; }
        [Required]
        public double HospitalTelephone { get; set; }
        [Required]
        public string  HospitalFaxNumber { get; set; }
        [Required]
        public string HospitalEmail { get; set; }
        [Required]
        public string HospitalMapCode { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
