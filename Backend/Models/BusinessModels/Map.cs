using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.Models.BusinessModels
{
    public class Map
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public ICollection<Building> placedBuildings { get; set; }
        public ICollection<Review> reviews { get; set; }

        public Map(double longitude, double latitude, ICollection<Building> placedBuildings)
        {
            this.longitude = longitude;
            this.latitude = latitude;
            this.placedBuildings = placedBuildings;
        }
    }
}
