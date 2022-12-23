namespace Backend.Models.BusinessModels
{
    public class Location
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; }
        public ICollection<Region> Regions { get; set; }
    }
}
