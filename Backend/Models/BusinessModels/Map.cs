using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.Models.BusinessModels
{
    public class Map
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int UserId { get; set; }
        public ICollection<Building> PlacedBuildings { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public Map()
        {

        }
        public Map(int id, double latitude, double longitude, int userId, ICollection<Building> placedBuildings, ICollection<Review> reviews)
        {
            Id = id;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.UserId = userId;
            this.PlacedBuildings = placedBuildings;
            this.Reviews = reviews;
        }
    }
}
