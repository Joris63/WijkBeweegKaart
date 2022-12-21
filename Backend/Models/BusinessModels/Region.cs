namespace Backend.Models.BusinessModels
{
    public class Region
    {
        public int Id { get; set; }
        public int MapId { get; set; }
        public Map Map { get; set; }
        public ICollection<Point> Points { get; set; }
    }
}