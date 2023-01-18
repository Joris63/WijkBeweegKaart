namespace Backend.Models.BusinessModels
{
    public class Region
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public ICollection<Point> Points { get; set; }
    }
}