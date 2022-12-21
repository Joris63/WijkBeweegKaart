namespace Backend.Models.BusinessModels
{
    public class Point
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}