using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public virtual Doctor Doctor { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public string Location { get; set; }
        public virtual WeekDay WeekDay { get; set; }
        [Required]
        public int WeekDayId { get; set; }
        [Required]
        public string ClinicStartTime { get; set; }
        [Required]
        public string ClinicEndTime { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int IsDeleted { get; set; }
    }
}
