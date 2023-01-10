namespace WebApplication2.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public virtual WeekDay WeekDay { get; set; }
        public int WeekDayId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public virtual Branch Branch { get; set; }
        public int BranchId { get; set; }

        public DateTime? CreatedOn { get; set; }
        public int IsDeleted { get; set; }
    }
}
