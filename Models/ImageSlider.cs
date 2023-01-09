namespace WebApplication2.Models
{
    public class ImageSlider
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public virtual Branch Branch { get; set; }
        public int BranchId { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}
