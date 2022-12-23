namespace Backend.Models.BusinessModels
{
    public class Map
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public ICollection<Building> PlacedBuildings { get; set; }
        public ICollection<Donation> Donations { get; set; }
        public ICollection<Region> Regions { get; set; }

        public Map()
        {

        }
    }
}
