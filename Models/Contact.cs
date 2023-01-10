namespace WebApplication2.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Branch Branch { get; set; }
        public int BranchId { get; set; }
        public string AddressDetails { get; set; }
        public double HospitalTelephone { get; set; }
        public double HospitalFaxNumber { get; set; }
        public string HospitalEmail { get; set; }
        public double HospitalMapCode { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
