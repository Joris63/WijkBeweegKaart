namespace Backend.Models.ViewModels
{
    public class MapViewModel
    {
        public int Id { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int userId { get; set; }
        public ICollection<BuildingViewModel> placedBuildings { get; set; }
        public ICollection<ReviewViewModel> reviews { get; set; }

        public MapViewModel(double longitude, double latitude, ICollection<BuildingViewModel> placedBuildings)
        {
            this.longitude = longitude;
            this.latitude = latitude;
            this.placedBuildings = placedBuildings;
        }
    }
}
