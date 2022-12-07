using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.Models.BusinessModels
{
    public class Map
    {
        public int Id { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int userId { get; set; }
        public ICollection<Building> placedBuildings { get; set; }
        public ICollection<Review> reviews { get; set; }

        public Map()
        {

        }
        public Map(int id, double latitude, double longitude, int userId, ICollection<Building> placedBuildings, ICollection<Review> reviews)
        {
            Id = id;
            this.latitude = latitude;
            this.longitude = longitude;
            this.userId = userId;
            this.placedBuildings = placedBuildings;
            this.reviews = reviews;
        }
    }
}
