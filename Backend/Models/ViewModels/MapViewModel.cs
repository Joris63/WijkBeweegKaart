namespace Backend.Models.ViewModels
{
    public class MapViewModel
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int UserId { get; set; }
        public ICollection<BuildingViewModel> PlacedBuildings { get; set; }
        public ICollection<ReviewViewModel>? Reviews { get; set; }

        public MapViewModel(double longitude, double latitude, ICollection<BuildingViewModel> placedBuildings)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.PlacedBuildings = placedBuildings;
        }
    }
}
