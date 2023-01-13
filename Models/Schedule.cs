namespace WebApplication2.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public string Location { get; set; }
        public virtual WeekDay WeekDay { get; set; }
        public int WeekDayId { get; set; }
        public DateTime ClinicStartTime { get; set; }
        public DateTime ClinicEndTime { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int IsDeleted { get; set; }
    }
}
